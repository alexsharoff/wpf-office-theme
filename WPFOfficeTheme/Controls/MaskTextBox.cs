#region Using

using System;
using System.Collections.Generic;
//using System.Linq;
using System.Text;
using System.Windows.Controls;
using System.Windows.Input;
using System.Diagnostics;
using System.Windows;
using System.ComponentModel; 

#endregion

namespace WPFOfficeTheme
{
	public class MaskTextBox : System.Windows.Controls.TextBox, INotifyPropertyChanged
	{
		# region Declare

		public event PropertyChangedEventHandler PropertyChanged;

		# endregion

		#region Constructor

		public MaskTextBox()
		{
			this.ContextMenu = null;
		}

		#endregion
			
		#region Properties

		#region FixedChars

		public Char[] FixedChars
		{
			get
			{
				List<char> fixedChars = new List<char>();
				for (int i = 0; i < this.Mask.Length; i++)
					if (this.GetMaskCharType(i) == MaskCharType.Fixed)
						if (!fixedChars.Contains(this.Mask[i]))
							fixedChars.Add(this.Mask[i]);

				return fixedChars.ToArray();
			}
		} 

		#endregion
		
		#region Mask

		public string Mask
		{
			get { return (string)GetValue(MaskProperty); }
			set 
			{ 
				SetValue(MaskProperty, value);
				this.InitializeMask();
			}
		}

		public static readonly DependencyProperty MaskProperty =
			DependencyProperty.Register("Mask", typeof(string), typeof(MaskTextBox),
				new FrameworkPropertyMetadata(null));

		#endregion

		#region BlankCharacter

		public char BlankCharacter
		{
			get { return (char)GetValue(BlankCharacterProperty); }
			set { SetValue(BlankCharacterProperty, value); }
		}

		public static readonly DependencyProperty BlankCharacterProperty =
			DependencyProperty.Register("BlankCharacter", typeof(char), typeof(MaskTextBox),
				new FrameworkPropertyMetadata(' '));

		#endregion 
				
		# region UnmaskedText

		private string _UnmaskedText;
		public string UnmaskedText
		{
			get
			{
				return _UnmaskedText;
			}
			set
			{
				this.InitializeMask();

				for (int i = 0; i < value.Length; i++)
				{
                    //Changed
                    if (Array.IndexOf(this.FixedChars, value[i]) == -1) 
					{
						this.AppendCharacter(value[i]);
					}
				}

				this._UnmaskedText = this.GetCleanValue();
				this.NotifyPropertyChanged("UnmaskedText");
			}
		}

		# endregion

		# region // UnmaskedText

		//public static readonly DependencyProperty UnmaskedTextProperty =
		//    DependencyProperty.Register("UnmaskedText", typeof(string),
		//    typeof(MaskTextBox), new FrameworkPropertyMetadata(string.Empty));

		//public string UnmaskedText
		//{
		//    get
		//    {
		//        return (string)this.GetValue(MaskTextBox.UnmaskedTextProperty);
		//    }
		//    set
		//    {
		//        this.InitializeMask();

		//        for (int i = 0; i < value.Length; i++)
		//        {
		//            if (!this.FixedChars.Contains(value[i]))
		//            {
		//                this.AppendCharacter(value[i]);
		//            }
		//        }

		//        string s = this.GetCleanValue();

		//        this.SetValue(MaskTextBox.UnmaskedTextProperty, s);
		//    }
		//}

		# endregion

		#region Text

		[Localizability(LocalizationCategory.Text), DefaultValue("")]
		public new string Text
		{
			get
			{
				return (string)base.GetValue(TextProperty);
			}
			private set
			{
				if (value.Length > 10)
				{
					string s = value;
				}
				base.SetValue(TextProperty, value);

				
			}
		} 

		#endregion

		#endregion
				
		#region Methods

		#region Overrides

		#region OnInitialized

		protected override void OnInitialized(EventArgs e)
		{
			base.OnInitialized(e);
			if (String.IsNullOrEmpty(this.Text))
			{
				this.InitializeMask();
			}
		}

		#endregion

		#region OnPreviewKeyDown

		protected override void OnPreviewKeyDown(System.Windows.Input.KeyEventArgs e)
		{
			if (e.Key == Key.Back)
			{
				#region Back

				if (this.SelectionStart - 1 >= this.GetFirstValidPosition())
				{
					int auxSelectionStart = this.SelectionStart;

					if (this.GetMaskCharType(auxSelectionStart - 1) == MaskCharType.Fixed)
					{
						this.SelectionStart = this.GetNextValidPositionFrom(auxSelectionStart, false) + 1;
					}
					else
					{
						this.UpdateCharacter(this.Text, this.BlankCharacter, auxSelectionStart - 1);
						this.SelectionStart = this.GetNextValidPositionFrom(auxSelectionStart, false);
					}

				}

				e.Handled = true;

				#endregion
			}
			else if (e.Key == Key.Delete)
			{
				#region Delete

				if (this.SelectionStart < this.Mask.Length)
				{
					int auxSelectionStart = this.SelectionStart;

					if (this.GetMaskCharType(auxSelectionStart) == MaskCharType.Fixed)
					{
						this.SelectionStart = this.GetNextValidPositionFrom(auxSelectionStart);
					}
					else
					{
						this.UpdateCharacter(this.Text, this.BlankCharacter, auxSelectionStart);
						this.SelectionStart = this.GetNextValidPositionFrom(auxSelectionStart);
					}

					e.Handled = true;
				}

				#endregion
			}
			else if (e.Key != Key.Home
					&& e.Key != Key.End
					&& e.Key != Key.Up
					&& e.Key != Key.Down
					&& e.Key != Key.Left
					&& e.Key != Key.Right
					&& e.Key != Key.Enter
					&& e.Key != Key.Tab
					&& !this.IsNumber(e.Key)
				)
			{
				e.Handled = true;
			}

			base.OnPreviewKeyDown(e);
		}

		#endregion

		#region OnPreviewTextInput

		protected override void OnPreviewTextInput(System.Windows.Input.TextCompositionEventArgs e)
		{
			e.Handled = true;
			this.AppendCharacter(e.Text[0]);
		}

		#endregion

		# region OnTextChanged

		protected override void OnTextChanged(TextChangedEventArgs e)
		{
			base.OnTextChanged(e);

			this._UnmaskedText = this.GetCleanValue();
			this.NotifyPropertyChanged("UnmaskedText");
			//this.UnmaskedText = this.GetCleanValue();
		}

		# endregion 

		#endregion

		#region GetCleanValue

		public string GetCleanValue()
		{
			string cleanValue = String.Empty;
			for (int i = 0; i < this.Text.Length; i++)
			{
				if (this.GetMaskCharType(i) != MaskCharType.Fixed && this.Text[i] != this.BlankCharacter)
				{
					cleanValue += this.Text[i].ToString();
				}
			}

			return cleanValue;
		}

		#endregion

		# region NotifyPropertyChanged

		private void NotifyPropertyChanged(String info)
		{
			if (PropertyChanged != null)
			{
				PropertyChanged(this, new PropertyChangedEventArgs(info));
			}
		}

		# endregion

		#region AppendCharacter

		private void AppendCharacter(char c)
		{
			if (this.SelectionStart >= this.Mask.Length) return;

			if (this.GetMaskCharType(this.SelectionStart) == MaskCharType.Fixed)
			{
				this.SelectionStart = this.GetNextValidPositionFrom(this.SelectionStart);
			}

			if (this.ValidateInput(this.SelectionStart, c))
			{
				int selectionStartAux = this.SelectionStart;
				this.UpdateCharacter(this.Text, c, this.SelectionStart);
				this.SelectionStart = this.GetNextValidPositionFrom(selectionStartAux);
			}
		}

		#endregion

		#region ValidateInput

		private bool ValidateInput(int index, char input)
		{
			switch (this.GetMaskCharType(index))
			{
				case MaskCharType.Number:
					return this.IsNumber(input);
				default:
					return false;
			}
		}

		#endregion

		# region InitializeMask

		private void InitializeMask()
		{
			if (this.Mask == null) return;

			var value = string.Empty;

			foreach (char c in this.Mask)
			{
				if (c == '0')
				{
					value += this.BlankCharacter.ToString();
				}
				else
				{
					value += c.ToString();
				}
			}

			this.Text = value;
		}

		# endregion

		#region GetMaskCharType

		private MaskCharType GetMaskCharType(int index)
		{
			char maskChar = this.Mask[index];

			if (maskChar == '0')
			{
				return MaskCharType.Number;
			}
			else
			{
				return MaskCharType.Fixed;
			}
		}

		#endregion

		#region IsNumber

		private bool IsNumber(Key key)
		{
			return this.IsNumber(KeyInterop.VirtualKeyFromKey(key));
		}

		private bool IsNumber(int key)
		{
			return ((key > 47 && key < 58) || (key > 95 && key < 106));
		}

		#endregion

		#region UpdateCharacter

		private void UpdateCharacter(string s, char c, int index)
		{
			this.Text = String.Format("{0}{1}{2}",
				s.Substring(0, Math.Max(0, index)),
				c.ToString(),
				s.Substring(index + 1, s.Length - index - 1));
		}

		#endregion

		#region GetNextValidCursorPosition

		private int GetNextValidPositionFrom(int actualPosition, bool searchForward)
		{
			int leaps = 0;
			return this.GetNextValidPositionFrom(actualPosition, searchForward, out leaps);
		}

		private int GetNextValidPositionFrom(int actualPosition)
		{
			int leaps = 0;
			return this.GetNextValidPositionFrom(actualPosition, true, out leaps);
		}

		private int GetNextValidPositionFrom(int actualPosition, bool searchForward, out int leaps)
		{
			leaps = 0;

			int increment = (searchForward ? 1 : -1);
			int validPosition = (searchForward ? this.GetLastValidPosition() + 1 : this.GetFirstValidPosition());
			actualPosition += increment;

			for (; actualPosition < this.Mask.Length && actualPosition > 0; actualPosition += increment)
			{
				if (this.GetMaskCharType(actualPosition) != MaskCharType.Fixed)
				{
					validPosition = actualPosition;
					break;
				}
				leaps++;
			}

			return validPosition;
		}

		#endregion

		#region GetLastValidPosition

		private int GetLastValidPosition()
		{
			for (int i = this.Mask.Length - 1; i > 0; i--)
			{
				if (this.GetMaskCharType(i) != MaskCharType.Fixed)
				{
					return i;
				}
			}

			return -1;
		}

		#endregion

		#region GetFirstValidPosition

		private int GetFirstValidPosition()
		{
			for (int i = 0; i < this.Mask.Length; i++)
			{
				if (this.GetMaskCharType(i) != MaskCharType.Fixed)
				{
					return i;
				}
			}

			return -1;
		}

		#endregion

		#endregion
				
		#region enum MaskCharType

		enum MaskCharType
		{
			Number,
			Fixed
		}

		#endregion
	}
}
