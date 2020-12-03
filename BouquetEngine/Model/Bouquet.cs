using System;
namespace BouquetEngine.Model
{
    public class Bouquet
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public string Description { get; set; }
        public string PictureUrl { get; set; }

        // constractor

        public Bouquet() { }

        public Bouquet(Guid id, string name, double price, string description, string pictureUrl)
        {
            this.Id = id;
            this.Name = name;
            this.Price = price;
            this.Description = description;
            this.PictureUrl = pictureUrl;
        }

        public override bool Equals(object obj)
        {
            if (obj == null || !(obj is Bouquet))
            {
                return false;
            }
            Bouquet other = obj as Bouquet;
            return this.Id.Equals(other.Id);
        }

        public override int GetHashCode()
        {
            if (this.Id == null)
            {
                return 0;
            }
            else
            {
                return this.Id.GetHashCode();
            }
        }
    }
}

