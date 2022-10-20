using combit.ReportServer.ClientApi;
using combit.ReportServer.ClientApi.Objects;
using System;
using System.Windows.Forms;

namespace ClientApiExample.Dialogs
{
    public partial class EditTimeTriggerDialog : Form
    {

        private readonly ReportTaskTimedTrigger _currentTrigger;

        public EditTimeTriggerDialog(ReportTaskTimedTrigger trigger)
        {
            _currentTrigger = trigger;

            InitializeComponent();


            // Load the properties from the specified trigger object to the controls:

            txtName.Text = trigger.Name;
            txtStartTime.Text = trigger.StartBoundary.ToLocalTime().ToString();   // note that all dates in the Report Server are in UTC time and need to be converted to the local timezone.
            if (trigger.EndBoundary.HasValue)
            {    // The end time is optional => EndBoundary is Nullable<DateTime>
                txtEndTime.Text = trigger.EndBoundary.Value.ToLocalTime().ToString();
            }

            // Check what type of trigger we have and choose the right tab:
            if (trigger is OneTimeTrigger)
            {
                tabControl1.SelectedTab = tabNoInterval;
            }
            else if (trigger is MinuteByMinuteTrigger)
            {
                MinuteByMinuteTrigger minuteTrigger = (trigger as MinuteByMinuteTrigger);
                tabControl1.SelectedTab = tabMinuteInterval;
                txtMinuteInterval.Text = minuteTrigger.MinuteInterval.ToString();
            }
            else if (trigger is HourlyTrigger)
            {
                HourlyTrigger hourlyTrigger = (trigger as HourlyTrigger);
                tabControl1.SelectedTab = tabHourlyInterval;
                txtHourInterval.Text = hourlyTrigger.HourInterval.ToString();
            }
            else if (trigger is DailyTrigger)
            {
                DailyTrigger dailyTrigger = (trigger as DailyTrigger);
                tabControl1.SelectedTab = tabDailyInterval;
                txtDayInverval.Text = dailyTrigger.DayInterval.ToString();
            }
            else if (trigger is WeeklyTrigger)
            {
                WeeklyTrigger weeklyTrigger = (trigger as WeeklyTrigger);
                tabControl1.SelectedTab = tabWeeklyInterval;
                txtWeekInterval.Text = weeklyTrigger.WeeksInterval.ToString();
                chkMonday.Checked = weeklyTrigger.OnMonday;
                chkTuesday.Checked = weeklyTrigger.OnTuesday;
                chkWednesday.Checked = weeklyTrigger.OnWednesday;
                chkThursday.Checked = weeklyTrigger.OnThursday;
                chkFriday.Checked = weeklyTrigger.OnFriday;
                chkSaturday.Checked = weeklyTrigger.OnSaturday;
                chkSunday.Checked = weeklyTrigger.OnSunday;
            }
            else if (trigger is MonthlyDaysTrigger)
            {
                MonthlyDaysTrigger daysOfMonthsTrigger = (trigger as MonthlyDaysTrigger);
                tabControl1.SelectedTab = tabMonthlyDays;
            }
            else if (trigger is MonthlyWeeksAndWeekDaysTrigger)
            {
                MonthlyWeeksAndWeekDaysTrigger weeksOfMonthsTrigger = (trigger as MonthlyWeeksAndWeekDaysTrigger);
                tabControl1.SelectedTab = tabMonthlyDaysOfWeek;
            }
            else if (trigger is QuarterlyTrigger)
            {
                QuarterlyTrigger quarterlyTrigger = (trigger as QuarterlyTrigger);
                tabControl1.SelectedTab = tabQuarterlyInterval;
            }
        }



        private async void btnOK_Click(object sender, EventArgs e)
        {
            // We need to create an instance of the correct trigger class for the selected interval type.
            // Each trigger type has a constructor that takes an existing trigger, so you can change the type but keep the Id and other internal data.

            ReportTaskTimedTrigger trigger = null;

            // No repetition - one time execution
            if (tabControl1.SelectedTab == tabNoInterval)
            {
                trigger = new OneTimeTrigger(_currentTrigger);
            }

            // Minute by Minute trigger
            else if (tabControl1.SelectedTab == tabMinuteInterval)
            {
                trigger = new MinuteByMinuteTrigger(_currentTrigger)
                {
                    MinuteInterval = int.Parse(txtMinuteInterval.Text)
                };
            }

            // Hourly trigger
            else if (tabControl1.SelectedTab == tabHourlyInterval)
            {
                trigger = new HourlyTrigger(_currentTrigger)
                {
                    HourInterval = int.Parse(txtHourInterval.Text)
                };
            }

            // Daily trigger
            else if (tabControl1.SelectedTab == tabDailyInterval)
            {
                trigger = new DailyTrigger(_currentTrigger)
                {
                    DayInterval = int.Parse(txtDayInverval.Text)
                };
            }

            // Weekly trigger
            else if (tabControl1.SelectedTab == tabWeeklyInterval)
            {
                trigger = new WeeklyTrigger(_currentTrigger)
                {
                    WeeksInterval = int.Parse(txtWeekInterval.Text),
                    OnMonday = chkMonday.Checked,
                    OnTuesday = chkTuesday.Checked,
                    OnWednesday = chkWednesday.Checked,
                    OnThursday = chkThursday.Checked,
                    OnFriday = chkFriday.Checked,
                    OnSaturday = chkSaturday.Checked,
                    OnSunday = chkSunday.Checked,
                };
            }

            // Days-of-month (1-31) trigger
            else if (tabControl1.SelectedTab == tabMonthlyDays)
            {
                trigger = new MonthlyDaysTrigger(_currentTrigger);
            }

            // Weeks (1-4) and week days (Mo-Su) trigger
            else if (tabControl1.SelectedTab == tabMonthlyDaysOfWeek)
            {
                trigger = new MonthlyWeeksAndWeekDaysTrigger(_currentTrigger);
            }

            // Quarterly trigger
            else if (tabControl1.SelectedTab == tabQuarterlyInterval)
            {
                trigger = new QuarterlyTrigger(_currentTrigger);
            }

            // Set the properties that are shared between all kinds of triggers
            trigger.Name = txtName.Text;
            trigger.StartBoundary = DateTime.Parse(txtStartTime.Text).ToUniversalTime();
            trigger.EndBoundary = (txtEndTime.Text.Length == 0 ? null : (DateTime?)DateTime.Parse(txtEndTime.Text).ToUniversalTime());   // EndBoundary is optional and may be null if not specified!


            // Then we can create or update the trigger for the current task:
            try
            {
                await trigger.CreateOrUpdateAsync();
                MessageBox.Show("The changes have been applied.");
                this.Close();
            }
            catch (ModelValidationFailedException ex)
            {
                // Display input errors at the controls with the invalid values:
                Program.ShowValidationErrorsAtControls(this, errorProvider1, ex);
            }
            catch (ReportServerApiException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
