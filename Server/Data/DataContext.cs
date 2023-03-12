using Microsoft.EntityFrameworkCore;

namespace BlazorEcommerce.Server.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Cart>().HasData(
                new Cart
                {
                    Id = 1,
                    TotalPrice = 0,
                }
            );
            modelBuilder.Entity<Category>().HasData(
                new Category
                {
                    Id = 1,
                    Name = "Books",
                    Url = "books"
                },
                new Category
                {
                    Id = 2,
                    Name = "Toys",
                    Url = "toys"
                },
                new Category
                {
                    Id = 3,
                    Name = "Video Games",
                    Url = "video-games"
                }
            );

            modelBuilder.Entity<Product>().HasData(
                new Product
                {
                    Id = 1,
                    Title = "In Search of Lost Time",
                    Description = "Swann's Way, the first part of A la recherche de temps perdu, Marcel Proust's seven-part cycle, was published in 1913. In it, Proust introduces the themes that run through the entire work. Swann's Way, the first part of A la recherche de temps perdu, Marcel Proust's seven-part cycle, was published in 1913. In it, Proust introduces the themes that run through the entire work. Swann's Way, the first part of A la recherche de temps perdu, Marcel Proust's seven-part cycle, was published in 1913. In it, Proust introduces the themes that run through the entire work.",
                    ImageUrl = "https://i0.wp.com/summarybook.online/wp-content/uploads/2020/04/In-Search-of-Lost-Time.jpg?fit=321%2C500&ssl=1",
                    Price = 24.95m,
                    CategoryId = 1,
                    CartId = 1,
                },
                new Product
                {
                    Id = 2,
                    Title = "Ulysses",
                    Description = "Ulysses chronicles the passage of Leopold Bloom through Dublin during an ordinary day, June 16, 1904. The title parallels and alludes to Odysseus. Ulysses chronicles the passage of Leopold Bloom through Dublin during an ordinary day, June 16, 1904. The title parallels and alludes to Odysseus. Ulysses chronicles the passage of Leopold Bloom through Dublin during an ordinary day, June 16, 1904. The title parallels and alludes to Odysseus. Ulysses chronicles the passage of Leopold Bloom through Dublin during an ordinary day, June 16, 1904. The title parallels and alludes to Odysseus. Ulysses chronicles the passage of Leopold Bloom through Dublin during an ordinary day, June 16, 1904. The title parallels and alludes to Odysseus. Ulysses chronicles the passage of Leopold Bloom through Dublin during an ordinary day, June 16, 1904. The title parallels and alludes to Odysseus.",
                    ImageUrl = "https://upload.wikimedia.org/wikipedia/commons/a/ab/JoyceUlysses2.jpg",
                    Price = 19.95m,
                    CategoryId = 1,
                    CartId = null,
                },
                new Product
                {
                    Id = 3,
                    Title = "Real Madrid – Santiago Bernabéu Stadium",
                    Description = "A build to capture the heart of any Real Madrid fan. This LEGO® Real Madrid – Santiago Bernabéu Stadium (10299) building kit for adults lets you build an accurate scale model version of one of the most celebrated soccer stadiums of all time. So kick back and take your time discovering all the details packed into this collectible model.",
                    ImageUrl = "https://www.lego.com/cdn/cs/set/assets/blte226ac95a59d6b48/10299.png?fit=bounds&format=webply&quality=80&width=170&height=170&dpr=1",
                    Price = 399.99m,
                    CategoryId = 2,
                    CartId = null,
                },
                new Product
                {
                    Id = 4,
                    Title = "THE LEGEND OF ZELDA: OCARINA OF TIME",
                    Description = "As a young boy, Link is tricked by Ganondorf, the King of the Gerudo Thieves. The evil human uses Link to gain access to the Sacred Realm, where he places his tainted hands on Triforce and transforms the beautiful Hyrulean landscape into a barren wasteland. Link is determined to fix the problems he helped to create, so with the help of Rauru he travels through time gathering the powers of the Seven Sages.",
                    ImageUrl = "https://upload.wikimedia.org/wikipedia/en/5/57/The_Legend_of_Zelda_Ocarina_of_Time.jpg",
                    Price = 19.99m,
                    CategoryId = 3,
                    CartId = 1,
                },
                new Product
                {
                    Id = 5,
                    Title = "Elden Ring",
                    Description = "Rise, Tarnished, and be guided by grace to brandish the power of the Elden Ring and become an Elden Lord in the Lands Between.\r\n\r\nIn the Lands Between ruled by Queen Marika the Eternal, the Elden Ring, the source of the Erdtree, has been shattered.",
                    ImageUrl = "https://image.api.playstation.com/vulcan/ap/rnd/202110/2000/phvVT0qZfcRms5qDAk0SI3CM.png",
                    Price = 59.99m,
                    CategoryId = 3,
                    CartId = 1,
                },
                new Product
                {
                    Id = 6,
                    Title = "LEGO® DC Batman™ Batmobile™ Tumbler",
                    Description = "The impressive model captures the iconic style of the battle-ready, crime-fighting machine from The Dark Knight™ Trilogy films.\n\nLEGO® DC Batman™ Batmobile™ Tumbler (76240) will stretch your construction skills and capture the style of one of the most iconic vehicles in cinema history.",
                    ImageUrl = "https://www.lego.com/cdn/cs/set/assets/blt755a6d05eac6630d/76240.png?format=webply&fit=bounds&quality=75&width=800&height=800&dpr=1",
                    Price = 269.99m,
                    CategoryId = 2,
                    CartId = 1,
                },
                new Product
                {
                    Id = 7,
                    Title = "Assassin’s Creed® IV Black Flag™",
                    Description = "The year is 1715. Pirates rule the Caribbean and have established their own lawless Republic where corruption, greediness and cruelty are commonplace.Among these outlaws is a brash young captain named Edward Kenway.",
                    ImageUrl = "https://cdn.akamai.steamstatic.com/steam/apps/242050/header.jpg?t=1670596397",
                    Price = 21.99m,
                    CategoryId = 3,
                    CartId = null,
                }
            );
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Cart> Carts { get; set; }

    }
}
