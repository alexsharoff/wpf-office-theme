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
using System.Windows.Controls.Primitives;
using System.Collections;

#endregion

namespace WPFOfficeTheme
{
	[TemplatePart(Name = SearchableComboBox.PART_ToggleButton, Type = typeof(ToggleButton))]
	[TemplatePart(Name = SearchableComboBox.PART_SearchButton, Type = typeof(Button))]
	[TemplatePart(Name = SearchableComboBox.PART_EditableTextBox, Type = typeof(TextBox))]
	[TemplatePart(Name = SearchableComboBox.PART_Popup, Type = typeof(Popup))]
	public class SearchableComboBox : System.Windows.Controls.ComboBox
	{
		#region Declare

		internal const string PART_ToggleButton = "PART_ToggleButton";
		private ToggleButton _PART_ToggleButton_Element;

		internal const string PART_SearchButton = "PART_SearchButton";
		private Button _PART_SearchButton_Element;

		internal const string PART_EditableTextBox = "PART_EditableTextBox";
		private TextBox _PART_EditableTextBox_Element;

		internal const string PART_Popup = "PART_Popup";
		private Popup _PART_Popup_Element;

		public static readonly RoutedEvent SearchEvent = EventManager.RegisterRoutedEvent("Search",
			RoutingStrategy.Bubble, typeof(RoutedEventHandler), typeof(SearchableComboBox));

		private bool _CanSearch = true;
		//private bool _CanChangeSelection = true;
		
		#endregion

		#region Constructor

		public SearchableComboBox()
		{
			
		}

		#endregion

		#region Events

		#region Search Event

		public event RoutedEventHandler Search
		{
			add { this.AddHandler(SearchableComboBox.SearchEvent, value); }
			remove { this.RemoveHandler(SearchableComboBox.SearchEvent, value); }
		}

		#endregion

		#region RaiseSearchEvent

		private void RaiseSearchEvent()
		{
			if (this._CanSearch)
			{
				RoutedEventArgs e = new RoutedEventArgs(SearchableComboBox.SearchEvent, this);
				this.RaiseEvent(e);
			}
		}

		#endregion 

		#endregion

		#region Properties

		#region MainItemsSource

		public IEnumerable MainItemsSource
		{
			get { return (IEnumerable)GetValue(MainItemsSourceProperty); }
			set { SetValue(MainItemsSourceProperty, value); }
		}

		public static readonly DependencyProperty MainItemsSourceProperty =
			DependencyProperty.Register("MainItemsSource", typeof(IEnumerable), typeof(SearchableComboBox),
				new FrameworkPropertyMetadata(null));

		#endregion

		#region IsLoading

		public bool IsLoading
		{
			get { return (bool)GetValue(IsLoadingProperty); }
			set { SetValue(IsLoadingProperty, value); }
		}

		public static readonly DependencyProperty IsLoadingProperty =
			DependencyProperty.Register("IsLoading", typeof(bool), typeof(SearchableComboBox),
				new FrameworkPropertyMetadata(false));

		#endregion 

		#region SeacrhAction

		public SeacrhActionType SeacrhAction
		{
			get { return (SeacrhActionType)GetValue(SeacrhActionProperty); }
			set { SetValue(SeacrhActionProperty, value); }
		}

		public static readonly DependencyProperty SeacrhActionProperty =
			DependencyProperty.Register("SeacrhAction", typeof(SeacrhActionType), typeof(SearchableComboBox),
				new FrameworkPropertyMetadata(SeacrhActionType.OnPressEnter | SeacrhActionType.OnSearchButtonClick | SeacrhActionType.OnTextChange)); 

		#endregion
		
		#endregion

		#region Methods

		#region SetItemsSource

		public void SetItemsSource(IEnumerable items)
		{
			string tempText = this.Text;
			int tempSelectionStart = this._PART_EditableTextBox_Element.SelectionStart;
			this.Tag = tempSelectionStart;

            //if (items.OfType<object>().Count() > 0)
            //{
            //    this.ItemsSource = items;
            //    this.IsDropDownOpen = false;
            //    this.IsDropDownOpen = true;
            //}

			this.SelectedIndex = -1;

			this._CanSearch = false;
			this.Text = tempText;
			this._CanSearch = true;
			this._PART_EditableTextBox_Element.SelectionStart = tempSelectionStart;
			this._PART_EditableTextBox_Element.SelectionLength = 0;
		}

		#endregion

		#region Overrides

		#region OnApplyTemplate

		public override void OnApplyTemplate()
		{
			base.OnApplyTemplate();

			this._PART_ToggleButton_Element = this.GetTemplateChild(SearchableComboBox.PART_ToggleButton) as ToggleButton;
			this._PART_Popup_Element = this.GetTemplateChild(SearchableComboBox.PART_Popup) as Popup;

			#region _PART_EditableTextBox_Element

			this._PART_EditableTextBox_Element = this.GetTemplateChild(SearchableComboBox.PART_EditableTextBox) as TextBox;

			if (this._PART_EditableTextBox_Element != null)
			{
				this._PART_EditableTextBox_Element.TextChanged += new TextChangedEventHandler(delegate(object sender, TextChangedEventArgs e)
				{
					if ((this.SeacrhAction & SeacrhActionType.OnTextChange) == SeacrhActionType.OnTextChange)
					{
						this.RaiseSearchEvent();
					}
				});
			}

			#endregion

			#region _PART_SearchButton_Element

			this._PART_SearchButton_Element = this.GetTemplateChild(SearchableComboBox.PART_SearchButton) as Button;

			if (this._PART_SearchButton_Element != null)
			{
				this._PART_SearchButton_Element.Click += new RoutedEventHandler(delegate(object sender, RoutedEventArgs e)
				{
					if (!this._PART_EditableTextBox_Element.IsFocused)
					{
						this._PART_EditableTextBox_Element.Focus();
						this._PART_EditableTextBox_Element.SelectionStart = this._PART_EditableTextBox_Element.Text.Length;
					}

					if ((this.SeacrhAction & SeacrhActionType.OnSearchButtonClick) == SeacrhActionType.OnSearchButtonClick)
					{
						this.RaiseSearchEvent();
					}
				});
			}

			#endregion
		}

		#endregion

		#region OnSelectionChanged

		protected override void OnSelectionChanged(SelectionChangedEventArgs e)
		{
			this._CanSearch = false;
			base.OnSelectionChanged(e);
			Debug.WriteLine("OnSelectionChanged");
			this._CanSearch = true;
		}

		#endregion

		#region OnLostFocus

		protected override void OnLostFocus(RoutedEventArgs e)
		{
			this._CanSearch = false;
			if (this.SelectedItem == null)
			{
				if (!String.IsNullOrEmpty(this.Text.Trim()))
				{
					foreach (object o in this.MainItemsSource)
					{
						if (o.ToString().ToLower().Contains(this.Text.Trim().ToLower()))
						{
							this.SelectedItem = o;
						}
					}
				}
			}
			else
			{
				this.Text = this.SelectedItem.ToString();
			}
			this._CanSearch = true;

			base.OnLostFocus(e);
		}

		#endregion  

		#region OnKeyDown

		protected override void OnKeyDown(KeyEventArgs e)
		{
			base.OnKeyDown(e);

			if (e.Key == Key.Enter && ((this.SeacrhAction & SeacrhActionType.OnPressEnter) == SeacrhActionType.OnPressEnter))
			{
				this.RaiseSearchEvent();
			}
		} 

		#endregion

		#endregion

		#endregion
	}

	#region enum SeacrhActionType

	[Flags]
	public enum SeacrhActionType
	{
		OnPressEnter = 1,
		OnTextChange = 2,
		OnSearchButtonClick = 4
	}

	#endregion
}
