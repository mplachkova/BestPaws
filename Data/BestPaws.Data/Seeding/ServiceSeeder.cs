namespace BestPaws.Data.Seeding
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using BestPaws.Data.Models;

    public class ServiceSeeder : ISeeder
    {
        public async Task SeedAsync(ApplicationDbContext dbContext, IServiceProvider serviceProvider)
        {
            if (dbContext.Services.Any())
            {
                return;
            }

            var serviceNames = new List<string>
            {
                "Vaccinations",
                "Rabbit Care",
                "Microchipping",
                "Laboratory Services",
                "Radiography",
                "Diet & Nutrition",
                "Surgery Services",
                "General Wellness",
            };
            var serviceDescriptions = new List<string>
            {
                "Relentlessly pursues moth poop in litter box,scratch the walls or get scared by doggo also cucumerro eat too much then proceed to regurgitate all over living room carpet while humans eat dinner yet chew foot human give me attention meow furrier and even more furrier hairball. I is not fat, i is fluffy where is my slave?",
                "Get my claw stuck in the dog's ear rub face on everything fat baby cat best buddy little guy intrigued by the shower stretch out on bed but plays league of legends i will ruin the couch with my claws. Meow i love cuddles making bread on the bathrobe. ",
                "Scratch leg; meow for can opener to feed me bite the neighbor's bratty kid, make muffins. Purr cat is love, cat is life. Enslave the hooman nap all day is good you understand your place in my world and nyan fluffness ahh cucumber!",
                "Chew iPad power cord lick butt and make a weird face no, you can't close the door, i haven't decided whether or not i wanna go out so purr like an angel destroy couch as revenge stares at human while pushing stuff off a table cat playing a fiddle in hey diddle diddle?",
                "Cat ass trophy human is behind a closed door, emergency! abandoned! meeooowwww!!! grab pompom in mouth and put in water dish show belly. Ask for petting soft kitty warm kitty little ball of furr. Purrr purr littel cat, little cat purr purr human give me attention meow.",
                "Claw at curtains stretch and yawn nibble on tuna ignore human bite human hand nya nya nyan so ignore the human until she needs to get up, then climb on her lap and sprawl hunt anything that moves trip owner up in kitchen i want food purr while eating pelt around the house and up and down stairs chasing phantoms.",
                "Your pillow is now my pet bed stare at guinea pigs meow for catto munch salmono. Meow in empty rooms this human feeds me, i should be a god. Lick human with sandpaper tongue wack the mini furry mouse fall asleep on the washing machine or dismember a mouse and then regurgitate parts of it on the family room floor.",
                "Try to jump onto window and fall while scratching at wall hide from vacuum cleaner yet eats owners hair then claws head freak human out make funny noise mow mow mow mow mow mow success now attack human, sniff sniff and put butt in owner's face. ",
            };

            for (int i = 0; i < serviceNames.Count; i++)
            {
                await dbContext.Services.AddAsync(new Service
                {
                    Name = serviceNames[i],
                    Description = serviceDescriptions[i],
                });
            }
        }
    }
}
