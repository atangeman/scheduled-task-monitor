using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskScheduler;

namespace ScheduledTaskMonitor.Models
{
    /// <summary>
    /// Model for storing information on scheduled tasks gathered from user machine.
    /// </summary>
    public class STaskModel : IRegisteredTask, IRunningTask
    {
        #region Fields

        private string _MachineName;
        private string _Name;
        private string _RunStatus;
        private string _UserID;
        private string _Path;
        private _TASK_STATE _State;
        private bool _Enabled;
        private DateTime _LastRunTime;
        private int _LastTaskResult;
        private int _NumberOfMissedRuns;
        private DateTime _NextRunTime;
        private ITaskDefinition _Definition;
        private string _Xml;

        #endregion Fields

        #region Properties

        /// <summary>
        /// Name of machine
        /// </summary>
        public string MachineName
        {
            get
            {
                return _MachineName;
            }
            set
            {
                _MachineName = value;
            }
        }

        /// <summary>
        /// Status of the task
        /// </summary>
        public string RunStatus
        {
            get
            {
                return _RunStatus;
            }
            private set
            {
                _RunStatus = value;
            }
        }

        /// <summary>
        /// UserID of user that created the task
        /// </summary>
        public string UserID
        {
            get
            {
                return _UserID;
            }
            set
            {
                _UserID = value;
            }
        }

        /// <summary>
        /// Name of task in scheduler
        /// </summary>
        public string Name
        {
            get
            {
                return _Name;
            }
            private set
            {
                _Name = value;
            }
        }

        /// <summary>
        /// Path of scheduled task on client machine
        /// </summary>
        public string Path
        {
            get
            {
                return _Path;
            }
            private set
            {
                _Path = value;
            }
        }

        /// <summary>
        /// Current state of scheduled task
        /// </summary>
        public _TASK_STATE State
        {
            get
            {
                return _State;
            }
            private set
            {
                _State = value;
            }
        }

        /// <summary>
        /// Boolean set to true when task is enabled.
        /// </summary>
        public bool Enabled
        {
            get
            {
                return _Enabled;
            }

            set
            {
                _Enabled = value;
            }
        }

        /// <summary>
        /// DateTime stamp of last run time.
        /// </summary>
        public DateTime LastRunTime
        {
            get
            {
                return _LastRunTime;
            }
        }

        /// <summary>
        /// Int value corresponding to code returned from last run result
        /// </summary>
        public int LastTaskResult
        {
            get
            {
                return _LastTaskResult;
            }
        }

        public int NumberOfMissedRuns
        {
            get
            {
                return _NumberOfMissedRuns;
            }
        }

        public DateTime NextRunTime
        {
            get
            {
                return _NextRunTime;
            }
        }

        public ITaskDefinition Definition
        {
            get
            {
                return _Definition;
            }
        }

        public string Xml
        {
            get
            {
                return _Xml;
            }
        }

        public string InstanceGuid
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public string CurrentAction
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public uint EnginePID
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        #endregion Properties

        #region Constructors 

        public STaskModel() { }

        #endregion Constructors 

        #region Methods

        /// <summary>
        /// Override of ToString method to return indentifying task information.
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return String.Format("{0} {1} {2}", MachineName, Name, State);
        }

        public IRunningTask Run(object @params)
        {
            return ((IRegisteredTask)this).Run(@params);
        }

        public IRunningTask RunEx(object @params, int flags, int sessionID, string user)
        {
            return ((IRegisteredTask)this).RunEx(@params, flags,sessionID, user);
        }

        public IRunningTaskCollection GetInstances(int flags)
        {
            throw new NotImplementedException();
        }

        public string GetSecurityDescriptor(int securityInformation)
        {
            return ((IRegisteredTask)this).GetSecurityDescriptor(securityInformation);
        }

        public void Stop(int flags)
        {
            ((IRegisteredTask)this).Stop(flags);
        }

        public void GetRunTimes(ref _SYSTEMTIME pstStart, ref _SYSTEMTIME pstEnd, ref uint pCount, IntPtr pRunTimes)
        {
            ((IRegisteredTask)this).GetRunTimes(pstStart, pstEnd, pCount, pRunTimes);
        }

        public void Stop()
        {
            ((IRunningTask)this).Stop();
        }

        public void Refresh()
        {
            ((IRunningTask)this).Refresh();
        }

        public void SetSecurityDescriptor(string sddl, int flags)
        {
            ((IRegisteredTask)this).GetSecurityDescriptor(flags);
        }

        #endregion Methods
    }
}
