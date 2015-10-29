namespace iRacing.Models.Cameras
{
    public partial class Groups
    {
        public long GroupNum { get; set; }
        public string GroupName { get; set; }
        public Camera[] Cameras { get; set; }
    }
}
