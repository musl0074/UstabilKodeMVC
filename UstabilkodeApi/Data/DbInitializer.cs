using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UstabilkodeApi.Models;

namespace UstabilkodeApi.Data
{
    public static class DbInitializer
    {
        public static void Seed(UstabilkodeContext context)
        {
            context.Database.EnsureCreated();

            if (context.Products.Any())
                return; // Already contains data

            var products = new Product[]
            {
                new Product("CD-Ord", "Læse- og skriveværktøjet CD-ORD er kendt for at forløse ordblinde børn og voksnes potentiale for at læse, skrive og lære.", 4.500),
                new Product("IntoWords", "IntoWords læser tekst op for dig på din computer, tablet eller smartphone. Når du skal skrive, får du hjælp af kontekstbaserede ordforslag, ordprædiktion og stavehjælp.", 4.500),
                new Product("SubReader School", "Hjælp læsesvage elever med oplæsning af undertekster", 0),
                new Product("C-Pen", "Skan ord eller sætninger ind på computeren, så de kan læses op.", 595.00),
                new Product("Grammateket", "Tjekker din tekst for fejl i stavning, grammatik og kommatering", 0),
                new Product("Hukommelsesleg Flex", "Online program designet til at træne arbejdshukommelsen hos børn og voksne", 995.00),
                new Product("Håndskanner", "Lille, mobil håndskanner, der gør tekster tilgængelige for oplæsning", 655.00),
                new Product("IT-Rygsæk", "De vigtigste hjælpemidler til læsning og skrivning samlet i én praktisk rygsæk", 14187.50),
                new Product("Matematikleg Flex", "Hjælp til elever med matematikvanskeligheder", 995.00),
                new Product("MindView AT", "Et læse- og skriveværktøj baseret på mindmapping", 0),
                new Product("MiVo", "Træner brugen af skrivehjælpen i CD-ORD og IntoWords", 0),
                new Product("Ordbøger til CD-ORD og IntoWords", "Ekstra ordbøger til CD-ORD og IntoWords - fx flere sprog", 0),
                new Product("LEGO Education Produkter", "LEGO Education produkter", 0)
            };
            products.ToList().ForEach((p) => context.Products.Add(p));
            context.SaveChanges();
        }
    }
}
