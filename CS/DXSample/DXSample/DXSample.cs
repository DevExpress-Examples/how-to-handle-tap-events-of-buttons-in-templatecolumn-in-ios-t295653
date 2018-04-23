using System;

using Xamarin.Forms;
using System.Collections.Generic;
using DevExpress.Mobile.DataGrid;
using DevExpress.Data;

namespace DXSample {
	public class App : Application {
		public App() {
			// The root page of your application
			//ImageSource im = ImageSource.FromResource("1.png");
			List<TestData> itemsSource = new List<TestData>();
			for(int i = 0; i < 5; i++) {
				itemsSource.Add(new TestData() { Id = i, Text = "Row " + i });
			}

			GridControl grid = new GridControl() {
				VerticalOptions = LayoutOptions.FillAndExpand,
				HorizontalOptions = LayoutOptions.FillAndExpand,
				AutoGenerateColumnsMode = AutoGenerateColumnsMode.None
			};
			grid.Columns.Add(new NumberColumn() { FieldName = "Id" });
			grid.Columns.Add(new TextColumn() { FieldName = "Text" });

			TemplateColumn templateColumn = new TemplateColumn();
			templateColumn.FieldName = "unbound";
			templateColumn.UnboundType = DevExpress.Data.UnboundColumnType.Object;
			templateColumn.DisplayTemplate = new DataTemplate(typeof(MyControl));
			grid.Columns.Add(templateColumn);

			grid.ItemsSource = itemsSource;

			MainPage = new ContentPage {
				Content = grid
			};
		}

		protected override void OnStart() {
			// Handle when your app starts
		}

		protected override void OnSleep() {
			// Handle when your app sleeps
		}

		protected override void OnResume() {
			// Handle when your app resumes
		}
	}

	public class TestData {
		public int Id { get; set; }
		public string Text { get; set; }
	}

	public class MyControl : ContentView {
		public MyControl() {
			Button button = new Button();
			button.Text = "Tap Me";
			button.Clicked += Click;
			this.Content = button;
		}

		void Click(object sender, EventArgs e) {
		}

		protected override void OnPropertyChanged(string propertyName) {
			base.OnPropertyChanged(propertyName);
			if(propertyName == "Width") {
				CellView cell = this.Parent as CellView;
				if(cell != null) {
					cell.BatchBegin();
					cell.InputTransparent = false;
					cell.BatchCommit();
				}
			}
		}
	}
}

