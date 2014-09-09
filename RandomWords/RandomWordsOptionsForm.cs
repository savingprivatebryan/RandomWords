using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Reflection;
using System.Text;
using System.Windows.Forms;

namespace RandomWords
{
	public partial class RandomWordsOptionsForm : Form
	{
		public RandomWordsOptionsForm()
		{
			InitializeComponent();

			//populate casing options
			var values = Enum.GetValues(typeof(CapitalizationMode));
			CapitalizationComboBox.DisplayMember = "Name";
			CapitalizationComboBox.ValueMember = "Value";
			var items = new List<object>();
			for (var i = 0; i <= values.Length - 1; i++)
			{
				//get the friendly name from the description attribute
				Type type = values.GetValue(i).GetType();
				string name = Enum.GetName(type, values.GetValue(i));
				FieldInfo field = type.GetField(name);
				if (field != null)
				{
					DescriptionAttribute attr = Attribute.GetCustomAttribute(field, typeof(DescriptionAttribute)) as DescriptionAttribute;
					if (attr != null)
					{
						name = attr.Description;
					}
				}

				items.Add(new { Name = name, Value = values.GetValue(i) });
			}
			CapitalizationComboBox.DataSource = items;
		}

		/// <summary>
		/// Shows the form with the current options.
		/// </summary>
		/// <param name="options"></param>
		/// <returns></returns>
		public RandomWordsOptions DoOptions(RandomWordsOptions options)
		{
			SetFormValuesFromOptions(options);

			if (ShowDialog() == DialogResult.OK)
			{
				return GetOptionsFromFormValues();
			}
			else
			{
				//return unchanged options
				return options;
			}

		}

		/// <summary>
		/// Builds a RandomWordsOptions object from the current form values.
		/// </summary>
		/// <returns></returns>
		public RandomWordsOptions GetOptionsFromFormValues()
		{
			RandomWordsOptions returnVal = new RandomWordsOptions();
			returnVal.NumberOfWordsInPassword = (int)NumberOfWordsNUD.Value;
			returnVal.WordDelimiter = WordDelimiterTextBox.Text;
			returnVal.CapitalizationMode = (CapitalizationMode)CapitalizationComboBox.SelectedValue;

			return returnVal;
		}

		/// <summary>
		/// Populates the form with supplied RandomWordsOptions object.
		/// </summary>
		/// <param name="options"></param>
		public void SetFormValuesFromOptions(RandomWordsOptions options)
		{
			NumberOfWordsNUD.Value = options.NumberOfWordsInPassword;
			WordDelimiterTextBox.Text = options.WordDelimiter;
			CapitalizationComboBox.SelectedValue = options.CapitalizationMode;
		}

		private void SaveButton_Click(object sender, EventArgs e)
		{
			DialogResult = DialogResult.OK;
			Close();
		}

		private void CancelButton_Click(object sender, EventArgs e)
		{
			DialogResult = DialogResult.Cancel;
			Close();
		}
	}
}
