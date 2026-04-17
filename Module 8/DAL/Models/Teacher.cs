namespace DAL.Models
{
    public class Teacher : Person
    {
        public string Course { get; set; }

        public override string ToString()
        {
            return $"{base.ToString()}, cours : {this.Course}";
        }
    }
}
