using Microsoft.EntityFrameworkCore;

namespace SurveyPortal.Models
{
    public static class SeedData
    {
        public static void EnsurePopulated(IApplicationBuilder app)
        {
            SurveyDbContext context = app.ApplicationServices
                .CreateScope().ServiceProvider
                .GetRequiredService<SurveyDbContext>();

            if (context.Database.GetPendingMigrations().Any())
            {
                context.Database.Migrate();
            }

            if (!context.Surveys.Any())
            {
                Random rand = new Random();

                var surveys = new List<Survey>
                {
                    new Survey
                    {
                        Title = "Customer Satisfaction Survey",
                        Description = "Help us improve our services by sharing your feedback",
                        Category = "Customer Service",
                        CreatedAt = DateTime.UtcNow.AddDays(-30).AddHours(-rand.Next(1, 12)).AddMinutes(-rand.Next(1, 60)),
                        IsActive = true,
                        SurveyAnswers = new List<SurveyAnswers>
                        {
                            new SurveyAnswers { Answer = "The service was excellent and exceeded my expectations." },
                            new SurveyAnswers { Answer = "Wait time was too long during peak hours." }
                        }
                    },
                    new Survey
                    {
                        Title = "Product Feedback Survey",
                        Description = "Tell us what you think about our new product line",
                        Category = "Products",
                        CreatedAt = DateTime.UtcNow.AddDays(-20).AddHours(-rand.Next(1, 12)).AddMinutes(-rand.Next(1, 60)),
                        IsActive = true,
                        SurveyAnswers = new List<SurveyAnswers>
                        {
                            new SurveyAnswers { Answer = "The new product design is sleek and user-friendly." },
                            new SurveyAnswers { Answer = "I was hoping for more customization options." }
                        }
                    },
                    new Survey
                    {
                        Title = "Website Usability Survey",
                        Description = "Rate your experience with our new website design",
                        Category = "Technology",
                        CreatedAt = DateTime.UtcNow.AddDays(-15).AddHours(-rand.Next(1, 12)).AddMinutes(-rand.Next(1, 60)),
                        IsActive = true,
                        SurveyAnswers = new List<SurveyAnswers>
                        {
                            new SurveyAnswers { Answer = "The website loads quickly and looks modern." },
                            new SurveyAnswers { Answer = "I had trouble finding the contact page." }
                        }
                    },
                    new Survey
                    {
                        Title = "Market Research Survey",
                        Description = "Help us understand your preferences and needs",
                        Category = "Research",
                        CreatedAt = DateTime.UtcNow.AddDays(-10).AddHours(-rand.Next(1, 12)).AddMinutes(-rand.Next(1, 60)),
                        IsActive = true,
                        SurveyAnswers = new List<SurveyAnswers>
                        {
                            new SurveyAnswers { Answer = "I prefer eco-friendly products even if they cost more." },
                            new SurveyAnswers { Answer = "I value functionality over aesthetics." }
                        }
                    },
                    new Survey
                    {
                        Title = "Employee Satisfaction Survey",
                        Description = "Internal survey for company staff",
                        Category = "Human Resources",
                        CreatedAt = DateTime.UtcNow.AddDays(-5).AddHours(-rand.Next(1, 12)).AddMinutes(-rand.Next(1, 60)),
                        IsActive = false,
                        SurveyAnswers = new List<SurveyAnswers>
                        {
                            new SurveyAnswers { Answer = "I appreciate the flexibility in working hours." },
                            new SurveyAnswers { Answer = "More training opportunities would be helpful." }
                        }
                    },
                    new Survey
                    {
                        Title = "Event Feedback Survey",
                        Description = "Share your thoughts about our recent conference",
                        Category = "Events",
                        CreatedAt = DateTime.UtcNow.AddDays(-2).AddHours(-rand.Next(1, 12)).AddMinutes(-rand.Next(1, 60)),
                        IsActive = true,
                        SurveyAnswers = new List<SurveyAnswers>
                        {
                            new SurveyAnswers { Answer = "The keynote speaker was very inspiring." },
                            new SurveyAnswers { Answer = "The sessions were informative, but the venue was crowded." }
                        }
                    },
                    new Survey
                    {
                        Title = "Health & Wellness Survey",
                        Description = "Tell us about your fitness and health habits",
                        Category = "Health",
                        CreatedAt = DateTime.UtcNow.AddDays(-25).AddHours(-rand.Next(1, 12)).AddMinutes(-rand.Next(1, 60)),
                        IsActive = false,
                        SurveyAnswers = new List<SurveyAnswers>
                        {
                            new SurveyAnswers { Answer = "I go to the gym three times a week and eat healthy." },
                            new SurveyAnswers { Answer = "I struggle to stay active due to my busy schedule." }
                        }
                    },
                    new Survey
                    {
                        Title = "Technology Adoption Survey",
                        Description = "We want to learn about your technology usage patterns",
                        Category = "Technology",
                        CreatedAt = DateTime.UtcNow.AddDays(-22).AddHours(-rand.Next(1, 12)).AddMinutes(-rand.Next(1, 60)),
                        IsActive = true,
                        SurveyAnswers = new List<SurveyAnswers>
                        {
                            new SurveyAnswers { Answer = "I adopt new technologies as soon as they are available." },
                            new SurveyAnswers { Answer = "I prefer to wait and see before trying new tools." }
                        }
                    },
                    new Survey
                    {
                        Title = "Social Media Trends Survey",
                        Description = "Help us analyze the latest trends in social media",
                        Category = "Social Media",
                        CreatedAt = DateTime.UtcNow.AddDays(-18).AddHours(-rand.Next(1, 12)).AddMinutes(-rand.Next(1, 60)),
                        IsActive = true,
                        SurveyAnswers = new List<SurveyAnswers>
                        {
                            new SurveyAnswers { Answer = "I use Instagram and TikTok daily to follow trends." },
                            new SurveyAnswers { Answer = "I’ve reduced my social media usage in the past year." }
                        }
                    },
                    new Survey
                    {
                        Title = "Education & Learning Survey",
                        Description = "Tell us about your learning preferences and challenges",
                        Category = "Education",
                        CreatedAt = DateTime.UtcNow.AddDays(-12).AddHours(-rand.Next(1, 12)).AddMinutes(-rand.Next(1, 60)),
                        IsActive = false,
                        SurveyAnswers = new List<SurveyAnswers>
                        {
                            new SurveyAnswers { Answer = "I prefer interactive online courses over traditional lectures." },
                            new SurveyAnswers { Answer = "Time management is the biggest challenge in learning for me." }
                        }
                    },
                    new Survey
                    {
                        Title = "Remote Work Experience Survey",
                        Description = "How do you feel about working remotely?",
                        Category = "Work",
                        CreatedAt = DateTime.UtcNow.AddDays(-9).AddHours(-rand.Next(1, 12)).AddMinutes(-rand.Next(1, 60)),
                        IsActive = true,
                        SurveyAnswers = new List<SurveyAnswers>
                        {
                            new SurveyAnswers { Answer = "Working from home improves my productivity." },
                            new SurveyAnswers { Answer = "I miss the face-to-face interaction with colleagues." }
                        }
                    },
                    new Survey
                    {
                        Title = "Customer Loyalty Survey",
                        Description = "We value our customers' loyalty. Share your experience!",
                        Category = "Customer Service",
                        CreatedAt = DateTime.UtcNow.AddDays(-6).AddHours(-rand.Next(1, 12)).AddMinutes(-rand.Next(1, 60)),
                        IsActive = true,
                        SurveyAnswers = new List<SurveyAnswers>
                        {
                            new SurveyAnswers { Answer = "I've been a customer for years because of your great support." },
                            new SurveyAnswers { Answer = "Occasional promotions keep me coming back." }
                        }
                    },
                    new Survey
                    {
                        Title = "E-commerce Experience Survey",
                        Description = "How easy was it to shop on our platform?",
                        Category = "E-commerce",
                        CreatedAt = DateTime.UtcNow.AddDays(-3).AddHours(-rand.Next(1, 12)).AddMinutes(-rand.Next(1, 60)),
                        IsActive = false,
                        SurveyAnswers = new List<SurveyAnswers>
                        {
                            new SurveyAnswers { Answer = "Checkout was seamless and fast." },
                            new SurveyAnswers { Answer = "I had issues with payment gateway during my last purchase." }
                        }
                    },
                    new Survey
                    {
                        Title = "Gaming Preferences Survey",
                        Description = "What types of games do you enjoy playing?",
                        Category = "Entertainment",
                        CreatedAt = DateTime.UtcNow.AddDays(-1).AddHours(-rand.Next(1, 12)).AddMinutes(-rand.Next(1, 60)),
                        IsActive = true,
                        SurveyAnswers = new List<SurveyAnswers>
                        {
                            new SurveyAnswers { Answer = "I enjoy open-world RPGs with strong storylines." },
                            new SurveyAnswers { Answer = "Multiplayer competitive games are my favorite." }
                        }
                    },
                    new Survey
                    {
                        Title = "Public Transportation Satisfaction Survey",
                        Description = "Rate your experience with public transport services",
                        Category = "Public Services",
                        CreatedAt = DateTime.UtcNow.AddHours(-rand.Next(1, 12)).AddMinutes(-rand.Next(1, 60)),
                        IsActive = true,
                        SurveyAnswers = new List<SurveyAnswers>
                        {
                            new SurveyAnswers { Answer = "Buses are generally on time and clean." },
                            new SurveyAnswers { Answer = "I'd like to see more frequent routes during evenings." }
                        }
                    }
                };

                context.Surveys.AddRange(surveys);
                context.SaveChanges();
            }
        }
    }
}
