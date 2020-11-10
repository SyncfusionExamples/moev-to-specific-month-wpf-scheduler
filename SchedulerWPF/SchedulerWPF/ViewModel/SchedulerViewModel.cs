using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Media;

namespace WpfScheduler
{
    public class SchedulerViewModel : INotifyPropertyChanged
    {
        private ObservableCollection<Meeting> meetings;
        private ObservableCollection<Brush> colorCollection;
        private ObservableCollection<string> meetingSubjectCollection;
       

        public event PropertyChangedEventHandler PropertyChanged;
        public SchedulerViewModel()
        {
            this.Meetings = new ObservableCollection<Meeting>();
            this.AddAppointmentDetails();
            this.AddAppointments();

        }
        public ObservableCollection<Meeting> Meetings
        {
            get
            {
                return this.meetings;
            }
            set
            {
                this.meetings = value;
                this.RaiseOnPropertyChanged("Meetings");
            }
        }

        private DateTime displaydate = new DateTime(2020, 11, 10, 10, 0, 0);
        public DateTime DisplayDate
        {
            get
            {
                return this.displaydate;
            }

            set
            {
                this.displaydate = value;
                this.RaiseOnPropertyChanged("DisplayDate");
            }
        }
        private void AddAppointmentDetails()
        {
            meetingSubjectCollection = new ObservableCollection<string>();
            meetingSubjectCollection.Add("BigDoor Board Meeting Paris, France");
            meetingSubjectCollection.Add("Development Meeting New York, U.S.A");
            meetingSubjectCollection.Add("Project Plan Meeting Kuala Lumpur, Malaysia");
            meetingSubjectCollection.Add("Support - Web Meeting  Dubai, UAE");
            meetingSubjectCollection.Add("Project Release Meeting  Istanbul, Turkey");
            meetingSubjectCollection.Add("Customer Meeting  Tokyo, Japan");
            meetingSubjectCollection.Add("Consulting with doctor  Amsterdam, Netherlands");

            this.colorCollection = new ObservableCollection<Brush>();
            this.colorCollection.Add(new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FFA2C139")));
            this.colorCollection.Add(new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FFD80073")));
            this.colorCollection.Add(new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FF1BA1E2")));
            this.colorCollection.Add(new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FFE671B8")));
            this.colorCollection.Add(new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FFF09609")));
            this.colorCollection.Add(new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FF339933")));
            this.colorCollection.Add(new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FF00ABA9")));
            this.colorCollection.Add(new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FFE671B8")));
            this.colorCollection.Add(new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FF1BA1E2")));
            this.colorCollection.Add(new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FFD80073")));
            this.colorCollection.Add(new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FFA2C139")));
            this.colorCollection.Add(new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FFA2C139")));
            this.colorCollection.Add(new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FFD80073")));
            this.colorCollection.Add(new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FF339933")));
            this.colorCollection.Add(new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FFE671B8")));
            this.colorCollection.Add(new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FF00ABA9")));
        }
        private void AddAppointments()
        {
            var today = displaydate;
            var random = new Random();
            for (int month = -1; month < 5; month++)
            {
                for (int day = -15; day < 15; day++)
                {
                    for (int count = 0; count < 2; count++)
                    {
                        var meeting = new Meeting();
                        meeting.EventName= meetingSubjectCollection[random.Next(meetingSubjectCollection.Count)];
                        meeting.color = colorCollection[random.Next(10)];
                        meeting.From = today.AddMonths(month).AddDays(random.Next(0, 28)).AddHours(random.Next(9, 18));
                        meeting.To = meeting.From.AddHours(2);
                        this.Meetings.Add(meeting);
                    }
                }
            }
        }
        private void RaiseOnPropertyChanged(string propertyName)
        {
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}




