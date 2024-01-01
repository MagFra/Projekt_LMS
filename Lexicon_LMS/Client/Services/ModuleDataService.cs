//using Lexicon_LMS.Client.Components;
//using Lexicon_LMS.Shared.Domain;
//using System.Reflection.PortableExecutable;
//using Module = Lexicon_LMS.Shared.Domain.Module;

//namespace MachineParkApp.Client.Services
//{
//    
//    public class ModuleDataService : IModuleDataService
//    {
//        public static List<Module> Modules { get; set; } = new List<Module>();
//        public ModuleDataService()
//        {
//            ModulesData.Add(new Module() 
//            { 
//              MachineID = 1,
//              Location = Location.Skövde,
//              Date = DateTime.Now,
//              MachineType = "Sensor",
//              Status = Status.online
//            });
//            Machines.Add(new Machine()
//            {
//              MachineID = 2,
//              Location = Location.Stockholm,
//              Date = DateTime.Now,
//              MachineType = "Sensor",
//              Status = Status.online
//            });
//            Machines.Add(new Machine()
//            {
//              MachineID = 3,
//              Location = Location.Göteborg,
//              Date = DateTime.Now,
//              MachineType = "Excavator",
//              Status = Status.online
//            });
//        }
//        public List<Module> GetModulesData()
//        {
//            return ModulesData;
//        }

//        public Machine GetMachine(int ID)
//        {
//            return Machines.FirstOrDefault(x => x.MachineID == ID);
//        }

//        public void DeleteMachine(int ID)
//        {
//            var Machine = Machines.FirstOrDefault(x => x.MachineID == ID);
//            if (Machine != null)
//            {
//                Machines.Remove(Machine);
//            }
//        }

//        public void UpdateMachine(Machine updatedMachine)
//        {
//            var machine = Machines.FirstOrDefault(d => d.MachineID == updatedMachine.MachineID);
//            if (machine != null)
//            {
//                machine.Location = updatedMachine.Location;
//                machine.Date = updatedMachine.Date;
//                machine.MachineType = updatedMachine.MachineType;
//                machine.Status = updatedMachine.Status;
//            }
//        }

//        public void AddMachine(Machine machine)
//        {
//            Random rnd = new Random();
//            machine.MachineID = rnd.Next(100000);
//            Machines.Add(machine);
//        }


//        public void AddedMachine(Machine Machine)
//        {
//            throw new NotImplementedException();
//        }
//    }
//}
