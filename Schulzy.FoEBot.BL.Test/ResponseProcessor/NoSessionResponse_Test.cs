using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Schulzy.FoEBot.BL.ResponseProcessor;
using Schulzy.FoEBot.Interface.ResponseProcessor;

namespace Schulzy.FoEBot.BL.Test.ResponseProcessor
{
    [TestClass]
    public class NoSessionResponse_Test
    {
        [TestMethod]
        public void CheckIfSession_is_inactive()
        {
            // Arrange
            string response =
                "[{\"url\":\"https:\\/\\/hu0.forgeofempires.com\\/start?nosession\",\"message\":\"Sajn\\u00e1ljuk, a munkameneted el\\u00e9v\\u00fclt. L\\u00e9pj be ism\\u00e9t!\",\"__class__\":\"Redirect\"}]";
            INoSessionResponse noSessionResponse = new NoSessionResponse();

            // Act
            bool returnValue = noSessionResponse.HasActiveSession(response);

            // Assert
            Assert.IsFalse(returnValue);
        }

        [TestMethod]
        public void CheckIfSession_is_active()
        {
            // Arrange 
            string response =
                "[{\"responseData\":true,\"requestClass\":\"MessageService\",\"requestMethod\":\"newMessage\",\"requestId\":1446,\"__class__\":\"ServerResponse\"},{\"responseData\":{\"time\":1550172325,\"__class__\":\"Time\"},\"requestClass\":\"TimeService\",\"requestMethod\":\"updateTime\",\"requestId\":1446,\"__class__\":\"ServerResponse\"},{\"responseData\":{\"resources\":{\"copper_coins\":9441,\"nanoparticles\":25,\"supplies\":173414889,\"money\":707446933,\"bionics\":331,\"dna_data\":376,\"plastics\":419,\"ferroconcrete\":2485,\"tavern_silver\":763887,\"carnival_coins\":200,\"forge_bowl_footballs\":200,\"rubber\":968,\"strategy_points\":4,\"petroleum\":2700,\"whaleoil\":819,\"flavorants\":2392,\"wool\":0,\"porcelain\":2383,\"diplomacy\":228,\"horns\":3,\"transester_gas\":34,\"mead\":31,\"bioplastics\":110,\"negotiation_game_turn\":0,\"stars\":20,\"glass\":673,\"vikings\":22,\"axes\":89,\"fertilizer\":603,\"luxury_materials\":2659,\"data_crystals\":460,\"tinplate\":6380,\"explosives\":2666,\"medals\":111183,\"coffee\":2479,\"coke\":594,\"tar\":2789,\"smart_materials\":313,\"wire\":2678,\"biogeochemical_data\":66,\"winter_matches\":0,\"artificial_scales\":125,\"algae\":5,\"cypress\":617,\"electromagnets\":355,\"machineparts\":2757,\"convenience_food\":2375,\"paper\":2021,\"premium\":7026,\"packaging\":2859,\"guild_expedition_attempt\":8,\"asbestos\":2613,\"wine\":574,\"purified_water\":24,\"nanowire\":36,\"dye\":326,\"marble\":435,\"expansions\":0,\"carnival_roses\":11,\"carnival_tickets\":11,\"carnival_hearts\":0,\"summer_tickets\":1,\"fall_apples\":85,\"summer_doubloons\":2,\"soccer_energy\":200,\"spring_lanterns\":50,\"robots\":383,\"alabaster\":466,\"sandstone\":429,\"cloth\":82,\"gems\":145,\"salt\":587,\"gold\":538,\"silk\":370,\"brass\":520,\"gunpowder\":520,\"preservatives\":329,\"herbs\":602,\"brick\":776,\"semiconductors\":182,\"fall_ingredient_apples\":2,\"fall_ingredient_cinnamon\":2,\"fall_ingredient_caramel\":2,\"paper_batteries\":39,\"superconductors\":93,\"limestone\":22,\"lead\":109,\"biolight\":76,\"ropes\":481,\"basalt\":542,\"honey\":295,\"talc\":540,\"papercrete\":343,\"renewable_resources\":408,\"ai_data\":20,\"ebony\":139,\"plankton\":75,\"gas\":261,\"fall_ingredient_pumpkins\":2,\"fall_ingredient_chocolate\":2,\"nutrition_research\":253,\"corals\":47,\"granite\":333,\"bronze\":853,\"translucent_concrete\":481,\"golden_rice\":504,\"pearls\":82,\"steel\":440,\"population\":13553,\"cryptocash\":503,\"tea_silk\":502,\"nanites\":466,\"textiles\":1172,\"filters\":230},\"__class__\":\"Resources\"},\"requestClass\":\"ResourceService\",\"requestMethod\":\"getPlayerResources\",\"requestId\":1446,\"__class__\":\"ServerResponse\"},{\"responseData\":{\"resources\":{\"strategy_points\":1550171626,\"carnival_roses\":1550172325,\"guild_expedition_attempt\":1550172325,\"carnival_tickets\":1550172325},\"__class__\":\"ResourceAutoRefill\"},\"requestClass\":\"ResourceService\",\"requestMethod\":\"getPlayerAutoRefills\",\"requestId\":1446,\"__class__\":\"ServerResponse\"},{\"responseData\":{\"updatedEntities\":[{\"id\":1083,\"player_id\":487767,\"cityentity_id\":\"J_Vikings_Diplomacy4\",\"type\":\"diplomacy\",\"x\":514,\"y\":15,\"connected\":1,\"state\":{\"current_product\":{\"product\":{\"resources\":{\"copper_coins\":16},\"__class__\":\"Resources\"},\"name\":\"P\\u00e1r darab\",\"production_time\":300,\"asset_name\":\"copper_0\",\"production_option\":1,\"__class__\":\"CityEntityProductionProduct\"},\"boosted\":false,\"is_motivated\":false,\"next_state_transition_in\":300,\"next_state_transition_at\":1550172625,\"__class__\":\"ProducingState\"},\"__class__\":\"CityMapEntity\"}],\"militaryProducts\":[],\"__class__\":\"CityProductionResult\"},\"requestClass\":\"CityProductionService\",\"requestMethod\":\"startProduction\",\"requestId\":1446,\"__class__\":\"ServerResponse\"}]";
            INoSessionResponse noSessionResponse = new NoSessionResponse();

            // Act
            bool returnValue = noSessionResponse.HasActiveSession(response);

            //Assert
            Assert.IsTrue(returnValue);
        }
    }
}
