namespace SOMOID.core.Models
{
    public class Subscription : Recourse
    {
        public int ModuleId { get => ModuleId; }
        public string EndPoint { get => EndPoint; }
        public string Events { get => Events; set => Events=value; }
    }
}
