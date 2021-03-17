using Phoenix.LayerBases.Entity;

namespace Phoenix.Live.Entity
{
    public class Password : IEntity<int>
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Pass { get; set; }
        public string Description { get; set; }
    }
}
