//using Lexicon_LMS.Shared.Domain;
//using System.Net.Http.Json;

//namespace Lexicon_LMS.Client.Services
//{
//    public class CourseDataService
//    {
//        private readonly HttpClient _httpClient;

//        public CourseDataService(HttpClient httpClient)
//        {
//            _httpClient = httpClient;
//        }

//        public async Task<List<CourseDTO>> GetCoursesAsync()
//        {
//            try
//            {
//                return await _httpClient.GetFromJsonAsync<List<CourseDTO>>("/api/Courses");
//            }
//            catch (Exception)
//            {
          
//                throw;
//            }
//        }
//    }
//}
