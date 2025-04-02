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

                context.Surveys.AddRange(
                    new Survey
                    {
                        Title = "Customer Satisfaction Survey",
                        Description = "Help us improve our services by sharing your feedback",
                        CreatedAt = DateTime.UtcNow.AddDays(-30)
                            .AddHours(-rand.Next(1, 12))
                            .AddMinutes(-rand.Next(1, 60)),
                        IsActive = true
                    },
                    new Survey
                    {
                        Title = "Product Feedback Survey",
                        Description = "Tell us what you think about our new product line",
                        CreatedAt = DateTime.UtcNow.AddDays(-20)
                            .AddHours(-rand.Next(1, 12))
                            .AddMinutes(-rand.Next(1, 60)),
                        IsActive = true
                    },
                    new Survey
                    {
                        Title = "Website Usability Survey",
                        Description = "Rate your experience with our new website design",
                        CreatedAt = DateTime.UtcNow.AddDays(-15)
                            .AddHours(-rand.Next(1, 12))
                            .AddMinutes(-rand.Next(1, 60)),
                        IsActive = true
                    },
                    new Survey
                    {
                        Title = "Market Research Survey",
                        Description = "Help us understand your preferences and needs",
                        CreatedAt = DateTime.UtcNow.AddDays(-10)
                            .AddHours(-rand.Next(1, 12))
                            .AddMinutes(-rand.Next(1, 60)),
                        IsActive = true
                    },
                    new Survey
                    {
                        Title = "Employee Satisfaction Survey",
                        Description = "Internal survey for company staff",
                        CreatedAt = DateTime.UtcNow.AddDays(-5)
                            .AddHours(-rand.Next(1, 12))
                            .AddMinutes(-rand.Next(1, 60)),
                        IsActive = false
                    },
                    new Survey
                    {
                        Title = "Event Feedback Survey",
                        Description = "Share your thoughts about our recent conference",
                        CreatedAt = DateTime.UtcNow.AddDays(-2)
                            .AddHours(-rand.Next(1, 12))
                            .AddMinutes(-rand.Next(1, 60)),
                        IsActive = true
                    },
                    new Survey
                    {
                        Title = "Health & Wellness Survey",
                        Description = "Tell us about your fitness and health habits",
                        CreatedAt = DateTime.UtcNow.AddDays(-25)
                            .AddHours(-rand.Next(1, 12))
                            .AddMinutes(-rand.Next(1, 60)),
                        IsActive = false
                    },
                    new Survey
                    {
                        Title = "Technology Adoption Survey",
                        Description = "We want to learn about your technology usage patterns",
                        CreatedAt = DateTime.UtcNow.AddDays(-22)
                            .AddHours(-rand.Next(1, 12))
                            .AddMinutes(-rand.Next(1, 60)),
                        IsActive = true
                    },
                    new Survey
                    {
                        Title = "Social Media Trends Survey",
                        Description = "Help us analyze the latest trends in social media",
                        CreatedAt = DateTime.UtcNow.AddDays(-18)
                            .AddHours(-rand.Next(1, 12))
                            .AddMinutes(-rand.Next(1, 60)),
                        IsActive = true
                    },
                    new Survey
                    {
                        Title = "Education & Learning Survey",
                        Description = "Tell us about your learning preferences and challenges",
                        CreatedAt = DateTime.UtcNow.AddDays(-12)
                            .AddHours(-rand.Next(1, 12))
                            .AddMinutes(-rand.Next(1, 60)),
                        IsActive = false
                    },
                    new Survey
                    {
                        Title = "Remote Work Experience Survey",
                        Description = "How do you feel about working remotely?",
                        CreatedAt = DateTime.UtcNow.AddDays(-9)
                            .AddHours(-rand.Next(1, 12))
                            .AddMinutes(-rand.Next(1, 60)),
                        IsActive = true
                    },
                    new Survey
                    {
                        Title = "Customer Loyalty Survey",
                        Description = "We value our customers' loyalty. Share your experience!",
                        CreatedAt = DateTime.UtcNow.AddDays(-6)
                            .AddHours(-rand.Next(1, 12))
                            .AddMinutes(-rand.Next(1, 60)),
                        IsActive = true
                    },
                    new Survey
                    {
                        Title = "E-commerce Experience Survey",
                        Description = "How easy was it to shop on our platform?",
                        CreatedAt = DateTime.UtcNow.AddDays(-3)
                            .AddHours(-rand.Next(1, 12))
                            .AddMinutes(-rand.Next(1, 60)),
                        IsActive = false
                    },
                    new Survey
                    {
                        Title = "Gaming Preferences Survey",
                        Description = "What types of games do you enjoy playing?",
                        CreatedAt = DateTime.UtcNow.AddDays(-1)
                            .AddHours(-rand.Next(1, 12))
                            .AddMinutes(-rand.Next(1, 60)),
                        IsActive = true
                    },
                    new Survey
                    {
                        Title = "Public Transportation Satisfaction Survey",
                        Description = "Rate your experience with public transport services",
                        CreatedAt = DateTime.UtcNow
                            .AddHours(-rand.Next(1, 12))
                            .AddMinutes(-rand.Next(1, 60)),
                        IsActive = true
                    }
                );
                context.SaveChanges();
            }
        }
    }
}
