namespace DAL.Models
{
    public class Student : Person
    {
        public double Average { get; set; }

        public override string ToString()
        {
            return $"{base.ToString()}, moyenne {this.Average}";
        }
    }
}
