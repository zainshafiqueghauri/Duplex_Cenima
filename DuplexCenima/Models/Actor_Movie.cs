namespace DuplexCenima.Models
{
    public class Actor_Movie
    {
        public int MoiveId { get; set; }
        public Movie Movies { get; set; }

        public int ActorId { get; set; }
        public Actor Actors { get; set; }
    }
}
