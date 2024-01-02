using Lexicon_LMS.Shared.Domain;
using Microsoft.AspNetCore.Components;

namespace Lexicon_LMS.Client.Components
{
    public partial class ModulesData
    {
        public List<Module> Modules { get; set; } = new List<Module>();

        [Parameter]
        public string ExtraCaption { get; set; } = string.Empty;
        protected override void OnInitialized()
        {
            base.OnInitialized();
            //MachineList.Add(new Machine() 
            //{ MachineID = Guid.NewGuid(), 
            //  Location = Location.Skövde,
            //  Date = new DateTime(),
            //  MachineType = "MachineType1", 
            //  Status = Status.online 
            //});

            //MachineList.Add(new Machine()
            //{
            //    MachineID = Guid.NewGuid(),
            //    Location = Location.Göteborg,
            //    Date = new DateTime(),
            //    MachineType = "MachineType2",
            //    Status = Status.offline
            //});

        }
    }
}

