using MLService.Enums;

namespace MLService.MassTransit.MLService.Requests
{
    public class CreateMachineRequest
    {
        public string MachineName { get; set; } 
        public string MachineDescription { get; set; }
        public MachineType MachineType { get; set; }
    }
}
