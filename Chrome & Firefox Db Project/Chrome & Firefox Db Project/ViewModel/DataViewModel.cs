using Dapper;
using Microsoft.Data.Sqlite;
using System.ComponentModel;
using System.Dynamic;

namespace Chrome___Firefox_Db_Project.ViewModel
{
    public class DataViewModel : INotifyPropertyChanged
	{
		dynamic? showingdata = new ExpandoObject();
        public event PropertyChangedEventHandler? PropertyChanged;
		public dynamic? ShowingData
		{
			get { return showingdata; }
			set { showingdata = value; RaisePropertyChanged(nameof(ShowingData)); }
		}
		public void RaisePropertyChanged(string PropertyName = "") => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(PropertyName));
		public bool ExecuteQuery(string Query)
		{
            using SqliteConnection MediaHistoryDb = new("Data Source=C:\\sqlite\\db\\Media History.db");
            using SqliteConnection PermissionsDb = new("Data Source=C:\\sqlite\\db\\permissions.db");
            using SqliteConnection RecentlyClosedTabsDb = new("Data Source=C:\\sqlite\\db\\recently_closed_tabs.db");
            bool Flag = true;
            ShowingData = null;
            try
            {
                ShowingData = MediaHistoryDb.Query<dynamic>(Query);
            }
            catch
            {
                try
                {
                    ShowingData = PermissionsDb.Query<dynamic>(Query);
                }
                catch
                {
                    try
                    {
                        ShowingData = RecentlyClosedTabsDb.Query<dynamic>(Query);
                    }
                    catch
                    {
                        Flag = false;
                    }
                }
            }
            return Flag;
        }
    }
}