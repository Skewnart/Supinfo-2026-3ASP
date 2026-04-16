namespace DAL.Models
{
    public abstract class Person
    {
        public int ID { get; set; }
        public string FirstName { get; set; }
        public string Lastname { get; set; }

        public override string ToString()
        {
            return $"{this.Lastname.ToUpper()} {this.FirstName}";
        }
    }
}
