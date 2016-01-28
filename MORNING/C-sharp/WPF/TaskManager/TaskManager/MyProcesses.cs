using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace TaskManager
{
    public class MyProcesses
    {
        public ObservableCollection<Process> Processes { get; set; }
        public Process CurrentProcess { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;

        private int amount;
        public int Amount
        {
            get
            {
                return amount;
            }
            set
            {
                amount = value;
                if (PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs("Amount"));
                }
            }
        }

        public MyProcesses()
        {
            Processes = new ObservableCollection<Process>(Process.GetProcesses());
            Amount = Processes.Count;
            CurrentProcess = Process.GetCurrentProcess();
        }

        public ObservableCollection<Process> FindProcessesByName(string processName) 
            { 
                Processes = new ObservableCollection<Process>(Processes.Where(process => process.ProcessName.ToLower() == processName.ToLower())); 
                return Processes; 
            }

        public ObservableCollection<Process> FilterProcessesById(string id)
        {
            Processes = new ObservableCollection<Process>(Processes.Where(process => process.Id.ToString().Contains(id)));
            return Processes;
        }

        public ObservableCollection<Process> FilterProcessesByName(string name)
        {
            Processes = new ObservableCollection<Process>(Processes.Where(process => process.ProcessName.ToLower().Contains(name.ToLower())));
            return Processes;
        }

        public class CompareProcessById : IEqualityComparer<Process>
        {
            public bool Equals(Process x, Process y)
            {
                return x.Id == y.Id;
            }

            public int GetHashCode(Process obj)
            {
                return obj.Id;
            }
        }
        public void UpdateProcesses() 
        { 

            List<Process> currentProcesses = Process.GetProcesses().ToList();
            var comparer = new CompareProcessById();

            List<Process> oldProcesses = Processes.Except(currentProcesses, comparer).ToList();
            foreach (var oldProcess in oldProcesses)
            {
                Processes.Remove(Processes.First(proc => proc.Id == oldProcess.Id));
            }

            List<Process> newProcesses = currentProcesses.Except(Processes, comparer).ToList();
            foreach (var newProcess in newProcesses)
            {
                Processes.Add(newProcess);
            }

            Amount = Processes.Count;
        } 
    }
}
