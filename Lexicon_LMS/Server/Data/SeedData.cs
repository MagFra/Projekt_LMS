using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Lexicon_LMS.Shared.Domain;
using Lexicon_LMS.Server.Models.Entities;
using static Duende.IdentityServer.Models.IdentityResources;
using System.Numerics;
using System;
using System.Drawing;

namespace Lexicon_LMS.Server.Data
{
	public class SeedData
	{
		public static ApplicationDbContext db = default!;
		public static UserManager<ApplicationUser> userManager = default!;
		public static RoleManager<IdentityRole> roleManager = default!;

		public static async Task InitAsync(ApplicationDbContext context, IServiceProvider services)
		{
			//##-< Setup >-####################################################################
			db = context;

			if (db.Roles.Any()) return;

			userManager = services.GetRequiredService<UserManager<ApplicationUser>>();
			roleManager = services.GetRequiredService<RoleManager<IdentityRole>>();
			//#################################################################################



			//##-< Seed Roles >-###############################################################
			var roleNames = new[] { "Teacher", "Student" };
			await AddRolesAsync(roleNames);
			//#################################################################################



			//##-< Seed ActivityTypes >-#######################################################
			var types = new[] { "E-learning", "Föreläsning", "Övningstillfälle", "Inlämningsuppgifter" };
			await AddActivityTypesAsync(types);
			//#################################################################################



			//##-< Seed Courses >-#############################################################
			// courses = (Description, StartDate, LengthDays, Name, LastApplicationDay)
			var courses = new (string, DateTime, int, string, DateTime)[]{
				("An introductory module covering the basics of programming, including syntax, control structures, and algorithmic problem-solving.", DateTime.Parse("2024-01-05"), 30, "Computer Science", DateTime.Parse("2024-02-01")),
				("Explores abnormal behavior, mental disorders, diagnostic criteria, treatment approaches, and societal perspectives on mental health.", DateTime.Parse("2024-01-10"), 45, "Psychology", DateTime.Parse("2024-02-15")),
				("Focuses on materials used in medical devices and implants, emphasizing properties, biocompatibility, and design considerations.", DateTime.Parse("2024-01-15"), 60, "Biomedical Engineering", DateTime.Parse("2024-03-01")),
				("Examines the development and implementation of environmental policies, regulations, and laws, considering the roles of government and organizations.", DateTime.Parse("2024-01-20"), 30, "Environmental Science", DateTime.Parse("2024-03-15")),
				("Covers fundamental marketing principles, including market analysis, consumer behavior, product development, pricing strategies, and promotional activities.", DateTime.Parse("2024-01-20"), 30, "Business Administration", DateTime.Parse("2024-03-15")),
				("Explores different political systems, institutions, and practices across countries, facilitating comparison and contrast of political structures and processes.", DateTime.Parse("2024-01-20"), 30, "Political Science", DateTime.Parse("2024-03-15")),
				("Focuses on soil mechanics and its applications in engineering, covering topics such as soil properties, foundation design, and slope stability analysis.", DateTime.Parse("2024-01-20"), 30, "Civil Engineering", DateTime.Parse("2024-03-15")),
				("Applies statistical methods to economic data, teaching students how to analyze and interpret economic phenomena using quantitative techniques.", DateTime.Parse("2024-01-20"), 30, "Economics", DateTime.Parse("2024-03-15")),
				("Explores principles of visual communication, including graphic elements, layout design, and the use of images and typography to convey effective messages.", DateTime.Parse("2024-01-20"), 30, "Graphic Design", DateTime.Parse("2024-03-15")),
				("Covers the application of nutrition principles in clinical settings, addressing topics such as nutritional assessments, dietary interventions, and the role of nutrition in managing health conditions.", DateTime.Parse("2024-01-20"), 30, "Nutrition and Dietetics", DateTime.Parse("2024-03-15")),

			};

			await AddCoursesAsync(courses);
			//#################################################################################



			//##-< Seed Modules >-#############################################################
			// modules = (CourseId, Name, Description, StartDate, LengthOfDays)
			var modules = new (int, string, string, DateTime, int)[]
			{
				(1,"Introduction to Programming","Basics of programming, including coding syntax, logic, and algorithm development.",DateTime.Parse("2024-01-12"),3),
				(1,"Data Structures and Algorithms","Study of fundamental data structures and algorithms for efficient problem-solving.",DateTime.Parse("2024-01-15"),7),
				(1,"Database Management Systems","Introduction to database design, management, and querying using SQL.",DateTime.Parse("2024-01-21"),10),
				(1,"Artificial Intelligence","Exploration of AI concepts, machine learning, and natural language processing.",DateTime.Parse("2024-02-02"),15),
				(1,"Software Engineering","Principles of software development, including design, testing, and project management.",DateTime.Parse("2024-02-17"),10),

				(2,"Introduction to Psychology","Overview of key psychological concepts, theories, and research methods.",DateTime.Parse("2024-01-5"),3),
				(2,"Abnormal Psychology","Examination of abnormal behavior, mental disorders, and therapeutic interventions.",DateTime.Parse("2024-01-8"),7),
				(2,"Cognitive Psychology","Study of mental processes such as memory, perception, and problem-solving.",DateTime.Parse("2024-01-15"),10),
				(2,"Social Psychology","Exploration of how individuals are influenced by social interactions and groups.",DateTime.Parse("2024-02-01"),15),
				(2,"Research Methods in Psychology","Introduction to research design, statistical analysis, and experimental methods.",DateTime.Parse("2024-02-17"),10),

				(3,"Introduction to Biomedical Engineering","Overview of the field, including medical devices, imaging, and biomechanics.",DateTime.Parse("2024-01-5"),3),
				(3,"Biomaterials","Study of materials used in medical applications, emphasizing biocompatibility.",DateTime.Parse("2024-01-8"),7),
				(3,"Medical Imaging","Principles and technologies behind medical imaging modalities.",DateTime.Parse("2024-01-15"),10),
				(3,"Biomechanics","Application of mechanical principles to biological systems.",DateTime.Parse("2024-02-01"),15),
				(3,"Biomedical Signal Processing","Analysis and processing of biological signals for medical applications.",DateTime.Parse("2024-02-17"),10),

				(4,"Introduction to Environmental Science","Overview of environmental issues, ecosystems, and human impact.",DateTime.Parse("2024-01-5"),3),
				(4,"Environmental Chemistry","Study of chemical processes in the environment and pollution.",DateTime.Parse("2024-01-8"),7),
				(4,"Ecology","Examination of interactions between organisms and their environments.",DateTime.Parse("2024-01-15"),10),
				(4,"Environmental Policy and Regulation","Analysis of policies, regulations, and legal frameworks in environmental management.",DateTime.Parse("2024-02-01"),15),
				(4,"Climate Change and Sustainability","Exploration of climate change science, impacts, and sustainable practices.",DateTime.Parse("2024-02-17"),10),

				(5,"Principles of Marketing","Fundamental marketing concepts, including market analysis, consumer behavior, and marketing strategies.",DateTime.Parse("2024-01-5"),3),
				(5,"Financial Accounting","Introduction to accounting principles, financial statements, and financial analysis.",DateTime.Parse("2024-01-8"),7),
				(5,"Organizational Behavior","Study of individual and group behavior within organizations, focusing on motivation, leadership, and communication.",DateTime.Parse("2024-01-15"),10),
				(5,"Operations Management","Principles of efficiently managing business operations, including production, logistics, and supply chain.",DateTime.Parse("2024-02-01"),15),
				(5,"Strategic Management","Examination of strategic planning, competitive analysis, and decision-making at the organizational level.",DateTime.Parse("2024-02-17"),10),

				(6,"Introduction to Political Science","Overview of key political concepts, institutions, and theories.",DateTime.Parse("2024-01-5"),3),
				(6,"Comparative Politics","Comparative analysis of political systems, governance structures, and political cultures across countries.",DateTime.Parse("2024-01-8"),7),
				(6,"International Relations","Study of global political interactions, diplomacy, and international organizations.",DateTime.Parse("2024-01-15"),10),
				(6,"Political Theory","Exploration of political philosophies, ideologies, and theoretical frameworks.",DateTime.Parse("2024-02-01"),15),
				(6,"Public Policy","Analysis of policy-making processes, implementation, and evaluation in the public sector.",DateTime.Parse("2024-02-17"),10),

				(7,"Structural Analysis and Design","Principles and techniques for analyzing and designing structures, including buildings and bridges.",DateTime.Parse("2024-01-5"),3),
				(7,"Geotechnical Engineering","Study of soil mechanics, foundation design, and earth structures.",DateTime.Parse("2024-01-8"),7),
				(7,"Transportation Engineering","Planning, design, and operation of transportation systems, including roads and highways.",DateTime.Parse("2024-01-15"),10),
				(7,"Environmental Engineering","Application of engineering principles to address environmental issues, such as water and air quality.",DateTime.Parse("2024-02-01"),15),
				(7,"Construction Management","Project management principles applied to construction projects, including scheduling, budgeting, and risk management.",DateTime.Parse("2024-02-17"),10),

				(8,"Microeconomics","Study of individual economic agents, markets, and resource allocation.",DateTime.Parse("2024-01-5"),3),
				(8,"Macroeconomics","Analysis of aggregate economic phenomena, including inflation, unemployment, and economic growth.",DateTime.Parse("2024-01-8"),7),
				(8,"Econometrics","Application of statistical methods to economic data for empirical analysis.",DateTime.Parse("2024-01-15"),10),
				(8,"International Economics","Examination of global economic interactions, trade, and international financial systems.",DateTime.Parse("2024-02-01"),15),
				(8,"Development Economics","Study of economic issues in developing countries, including poverty, inequality, and economic growth.",DateTime.Parse("2024-02-17"),10),

				(9,"Visual Communication","Principles of conveying messages visually through graphic elements, layout, and design.",DateTime.Parse("2024-01-5"),3),
				(9,"Digital Imaging","Techniques for manipulating and enhancing digital images using graphic design software.",DateTime.Parse("2024-01-8"),7),
				(9,"Typography","Study of typefaces, fonts, and the art of arranging text for effective communication.",DateTime.Parse("2024-01-15"),10),
				(9,"Web Design","Principles of designing and creating user-friendly and visually appealing websites.",DateTime.Parse("2024-02-01"),15),
				(9,"Motion Graphics","Creation of animated and dynamic visual content using graphic design tools.",DateTime.Parse("2024-02-17"),10),

				(10,"Human Nutrition","Study of essential nutrients, dietary guidelines, and their impact on human health.",DateTime.Parse("2024-01-5"),3),
				(10,"Food Chemistry","Examination of the chemical composition of food and its effects on nutrition.",DateTime.Parse("2024-01-8"),7),
				(10,"Clinical Nutrition","Application of nutrition principles to manage and prevent health conditions in clinical settings.",DateTime.Parse("2024-01-15"),10),
				(10,"Community Nutrition","Study of nutrition programs, education, and interventions at the community level.",DateTime.Parse("2024-02-01"),15),
				(10,"Nutritional Assessment and Counseling","Techniques for assessing nutritional status and providing personalized dietary counseling.",DateTime.Parse("2024-02-17"),10),

			};
			await AddModulesAsync(modules);
			//#################################################################################



			//##-< Seed Activities >-##########################################################
			// activities = (Name, Descrition, StartDate, LenthDays, ModuleId, ActivityTypeId)

			var activities = new (string, string, DateTime, int, int, int)[] {

				("Föreläsning", "Introduction to Programming.", DateTime.Parse("2024-01-12"), 14, 1, 1),
				("Föreläsning", "Data Structures and Algorithms", DateTime.Parse("2024-01-15"), 14, 2, 1),
				("Föreläsning", "Database Management Systems", DateTime.Parse("2024-01-21"), 14, 3, 1),
				("Föreläsning", "Artificial Intelligence", DateTime.Parse("2024-01-21"), 14, 4, 1),
				("Föreläsning", "Software Engineering", DateTime.Parse("2024-01-21"), 14, 5, 1),

				("Föreläsning", "Introduction to Psychology", DateTime.Parse("2024-01-05"), 14, 6, 1),
				("Föreläsning", "Data Structures and Algorithms", DateTime.Parse("2024-01-05"), 14, 7, 1),
				("E-Learning", "Algorithms", DateTime.Parse("2024-01-06"), 14, 7, 2),


				};
			await AddActivitiesAsync(activities);
			//#################################################################################



			//##-< Seed Users >-###############################################################
			// usres = (E-mail, PassWord, FirstName, LastName, Role, CourseId)
			var users = new (string, string, string, string, string?, int?)[] {
				("teach1@lex.se", "%T0lss1t5", "Urban", "Levander", "Teacher", null),
				("teach2@lex.se","%T0lss1t5", "Karin", "Östman", "Teacher", null),
				("student1@home.se","%T0lss1t5", "Stefan", "Olsson", "Student", 1),
				("student2@home.se","%T0lss1t5", "Greta", "Sturesson", "Student", 2),


				("emil.andersson@home.se","%T0lss1t5", "Emil", "Andersson", "Student", 1),
				("viktor.johansson@home.se","%T0lss1t5", "Viktor", "Johansson", "Student", 2),
				("h.gustafsson@home.se","%T0lss1t5", "Sofia", "Gustafsson", "Student", 4),
				("blomman.b@home.se","%T0lss1t5", "Axel", "Bergqvist", "Student", 5),
				("jaggillarkatter@home.se","%T0lss1t5", "Isabella", "Eriksson", "Student", 6),
				("oscar.s@home.se","%T0lss1t5", "Oscar", "Svensson", "Student", 7),
				("clara.horses@home.se","%T0lss1t5", "Clara", "Larsson", "Student", 8),
				("stella.eri@home.se","%T0lss1t5", "Stella", "Eriksson", "Student", 9),
				("novalovasvensson@home.se","%T0lss1t5", "Nova", "Svensson", "Student", 10),
				("eliasnilsson@home.se","%T0lss1t5", "Elias", "Nilsson", "Student", 1),
				("lurre@home.se","%T0lss1t5", "Lucas", "Lundgren", "Student", 2),
				("emilia1982@home.se","%T0lss1t5", "Emilia", "Dahlström", "Student", 3),
				("majaisthebest@home.se","%T0lss1t5", "Maja", "Karlsson", "Student", 4),
				("liamlarsson@home.se","%T0lss1t5", "Liam", "Larsson", "Student", 5),
				("linnea.persson@home.se","%T0lss1t5", "Linnea", "Persson", "Student", 5),
				("sebastian_andersson@home.se","%T0lss1t5", "Sebastian", "Andersson", "Student", 3),
				("hugo.l@home.se","%T0lss1t5", "Hugo", "Lindqvist", "Student", 2),
				("a.gustafsson@home.se","%T0lss1t5", "Alva", "Gustafsson", "Student", 3),
				("superwilma@home.se","%T0lss1t5", "Wilma", "Bergström", "Student", 4),
				("klarafardigaga@home.se","%T0lss1t5", "Klara", "Jansson", "Student", 1),
				("stellaostman@home.se","%T0lss1t5", "Stella", "Östman", "Student", 2),
				("thea.b@home.se","%T0lss1t5", "Thea", "Berggren", "Student", 3),
				("gabbe1990@home.se","%T0lss1t5", "Gabriel", "Svensson", "Student", 4),
				("elin.lundin@home.se","%T0lss1t5", "Elin", "Lundin", "Student", 5),
				("benji.falken@home.se","%T0lss1t5", "Benjamin", "Falk", "Student", 6),
				("joel.lindell@home.se","%T0lss1t5", "Joel", "Lindell", "Student", 7),
				("bara.vara.vera@home.se","%T0lss1t5", "Vera", "Gustavsson", "Student", 8),
				("olivia.b@home.se","%T0lss1t5", "Olivia", "Björk", "Student", 9),
				("erik_karlberg@home.se","%T0lss1t5", "Erik", "Karlberg", "Student", 10),
				("simon_n@home.se","%T0lss1t5", "Simon", "Nyström", "Student", 1),
				("aliceiunderlandet1980@home.se","%T0lss1t5", "Alice", "Nilsson", "Student", 2),
				("ella_slangbella@home.se","%T0lss1t5", "Ella", "Andersson", "Student", 3),
				("noah.eklund@home.se","%T0lss1t5", "Noah", "Eklund", "Student", 4),
				("anton_persson@home.se","%T0lss1t5", "Anton", "Persson", "Student", 5),
				("linneadahlberg@home.se","%T0lss1t5", "Linnea", "Dahlberg", "Student", 5),
				("isak.b@home.se","%T0lss1t5", "Isak", "Bergman", "Student", 3),
				("viktigaviktor@home.se","%T0lss1t5", "Viktor", "Holmström", "Student", 2),
				("oliver.oberg@home.se","%T0lss1t5", "Oliver", "Öberg", "Student", 3),
				("anton_ericsson@home.se","%T0lss1t5", "Anton ", "Ericsson", "Student", 4)


			};

			await AddUsersAsync(users);
			//#################################################################################


		}
		//#####################################################################################

        //#####################################################################################



		//##-< Seed Roles Method >-############################################################
		private static async Task AddRolesAsync(string[] roleNames)
		{
			foreach (var roleName in roleNames)
			{
				if (await roleManager.RoleExistsAsync(roleName)) continue;
				var role = new IdentityRole { Name = roleName };
				var result = await roleManager.CreateAsync(role);

				if (!result.Succeeded) throw new Exception(string.Join("\n", result.Errors));

			}
			await db.SaveChangesAsync();
		}
		//#####################################################################################

        //#####################################################################################



		//##-< Seed Users Method >-############################################################
		private static async Task AddUsersAsync((string, string, string, string, string?, int?)[] users)
		{
			string email, pw, firstName, lastName; string? role; int? courseId;

			foreach (var user in users)
			{
				(email, pw, firstName, lastName, role, courseId) = user!;
				if (await userManager.FindByEmailAsync(email) != null) continue;
				var newUser = new ApplicationUser
				{
					UserName = email,
					Email = email,
					EmailConfirmed = true,
					FirstName = firstName,
					LastName = lastName,
					CourseId = courseId,
				};
				var result = await userManager.CreateAsync(newUser, pw);

				if (!result.Succeeded) throw new Exception(string.Join("\n", result.Errors));

				if (role != null)
				{
					await AddUserToRoleAsync(newUser, role);
				}
			}
			await db.SaveChangesAsync();
		}
		//#####################################################################################

        //#####################################################################################



		//##-< Method to connect a User to a Role >-###########################################
		private static async Task AddUserToRoleAsync(ApplicationUser user, string roleName)
		{
			if (!await userManager.IsInRoleAsync(user, roleName))
			{
				var result = await userManager.AddToRoleAsync(user, roleName);
				if (!result.Succeeded) throw new Exception(string.Join("\n", result.Errors));
			}
		}
		//#####################################################################################



		//##-< Seed Courses Method >-#####################################################################
		private static async Task AddCoursesAsync((string, DateTime, int, string, DateTime)[] courses)
		{
			string description, name; DateTime lastApplicationDay, startDate; int lenthDays;

			foreach (var course in courses)
			{
				(description, lastApplicationDay, lenthDays, name, startDate) = course;
				await db.courses.AddAsync(new Courses
				{
					Description = description,
					Name = name,
					LastApplicationDay = lastApplicationDay,
					StartDate = startDate,
					LengthDays = lenthDays
				});
			}
			await db.SaveChangesAsync();
		}
		//#####################################################################################



		//##-< Seed Modules Method >-##########################################################
		private static async Task AddModulesAsync((int, string, string, DateTime, int)[] modules)
		{
			// modules = (CourseId, Name, Description, StartDate, LengthOfDays)
			string description, name; int courseId, lengthOfDays; DateTime startDate;

			foreach (var module in modules)
			{

				(courseId, name, description, startDate, lengthOfDays) = module;

				await db.module.AddAsync(new Module
				{
					CourseId = courseId,
					Name = name,
					Description = description,
					StartDate = startDate,
					LengthOfDays = lengthOfDays,
				});
			}
			db.SaveChanges();
		}
		//#################################################################################



		//##-< Seed ActivityTypes Method >-#####################################################################
		private static async Task AddActivityTypesAsync(string[] types)
		{
			foreach (var type in types)
			{
				await db.ActivityType.AddAsync(new ActivityType { Type = type });
			}
			await db.SaveChangesAsync();
		}
		//#################################################################################



		//##-< Seed Activities Method >-###################################################
		private static async Task AddActivitiesAsync((string, string, DateTime, int, int, int)[] activities)
		{
			// activities = (Name, Descrition, StartDate, LenthDays, ModuleId, ActivityTypeId)
			string name, description; DateTime startDate; int lengthDays, moduleId, activityTypeId;

			foreach (var activityType in activities)
			{
				(name, description, startDate, lengthDays, moduleId, activityTypeId) = activityType;
				await db.activity.AddAsync(new Activities
				{
					Name = name,
					Description = description,
					StartDate = startDate,
					LenthDays = lengthDays,
					ModuleId = moduleId,
					ActivityTypeId = activityTypeId
				});
			}
			await db.SaveChangesAsync();
		}
		//#################################################################################



		//##-< name >-#####################################################################
		//#################################################################################



		//##-< name >-#####################################################################
		//#################################################################################
	}
}