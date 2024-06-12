using HabitGuiderMobileSol.Data;
using HabitGuiderMobileSol.Models;

namespace HabitGuiderMobileSol.Popups;

public partial class CreateHabitLogPopup
{
	private readonly DatabaseContext _databaseContext;
	public CreateHabitLogPopup()
	{
		InitializeComponent();
	}

	private async Task<Log> GetCurrentHabitLastLog(int habitId)
	{	
		Log lastLog = new();

		if (habitId != 0) 
		{
            lastLog = await _databaseContext.GetItemByKeyAsync<Log>(habitId);
		}
		return lastLog;
	}

	private async Task SubmitHabitLogBtnClicked(object sender, EventArgs e)
	{
		var habitId = Preferences.Get("CurrentHabitId", 0);
        Log lastLog = await GetCurrentHabitLastLog(habitId);
		if (lastLog == null)
		{
			//create log
			//(probably should create an initial log when creating habit)
		}
		else
		{
			//update log
		}
		// clear preferences
		// close popup
	}
}