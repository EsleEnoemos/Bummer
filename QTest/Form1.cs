using System;
using System.Windows.Forms;
using Quartz;
using Quartz.Impl;

namespace QTest {
	public partial class Form1 : Form {
		public Form1() {
			InitializeComponent();
			// Instantiate the Quartz.NET scheduler
			StdSchedulerFactory schedulerFactory = new StdSchedulerFactory();
			IScheduler scheduler = schedulerFactory.GetScheduler();

			// Instantiate the JobDetail object passing in the type of your
			// custom job class. Your class merely needs to implement a simple
			// interface with a single method called "Execute".
			JobDetail job = new JobDetail( "job1", "group1", typeof( MyJobClass ) );
			
			DateTime now = DateTime.Now.AddMinutes( 1 );
			DateTime dt = new DateTime(now.Year, now.Month, now.Day, now.Hour, now.Minute, 0 );
			CronTrigger trigger = new CronTrigger( "trigger 1", "group1", "job1", "group1", "5 * * * * ?" );
			//CronTrigger ct = new CronTrigger( "trigger 1", "group1", "job1", "group1", "5 * * * * ?" );
			//SimpleTrigger trigger = new SimpleTrigger( "trigger 1", new DateTime( dt.ToFileTimeUtc() ), null, SimpleTrigger.RepeatIndefinitely, new TimeSpan( 0, 0, 0, 15 ) );
			//trigger.JobName = "job1";
			//trigger.Group = "group1";
			//trigger.JobGroup = "group1";
			// Instantiate a trigger using the basic cron syntax.
			// This tells it to run at 1AM every Monday - Friday.
			// Add the job to the scheduler
			scheduler.AddJob( job, true );
			scheduler.ScheduleJob( trigger );
			scheduler.Start();

		}
		
	}
	public class MyJobClass : IJob {
		public int ID;
		public void Execute( JobExecutionContext context ) {
			Console.WriteLine( "executing..." + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") );
		}
	}
}
