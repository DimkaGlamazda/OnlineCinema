using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineCinema.BL.Model
{
    public class MockMovieView
    {
        private List<MockMovie> _listMockMovie;
        public MockMovieView()
        {
            _listMockMovie = new List<MockMovie>();
            Initialization();
        }

        private void Initialization()
        {
            _listMockMovie.Add
                  (new MockMovie()
                      {
                          poster = "https://cinema.moscow/system/uploads/cover/image/7697/843479.jpg",
                          name = "Фантастические звери: Преступления Гриндельвальда",
                          year = "Великобритания, США, 2018",
                          genre = "Фантастика, боевик, приключения",
                          director = "Дэвид Йэтс",
                          cast = "Эдди Редмэйн, Джуд Лоу, Джонни Депп, Зои Кравитц, Кэтрин Уотерстоун, Дэн Фоглер, Элисон Судол, Эзра Миллер",
                          duration = "134 мин.",
                          about = "Могущественный тёмный волшебник Геллерт Грин-де-Вальд пойман в Штатах, но не собирается молча сидеть в темнице и устраивает грандиозный побег. Теперь ничто не помешает ему добиться своей цели — установить превосходство волшебников над всеми немагическими существами на планете. Чтобы сорвать планы Грин-де-Вальда, Альбус Дамблдор обращается к своему бывшему студенту Ньюту Саламандеру, который соглашается помочь, не подозревая, какая опасность ему грозит. В раскалывающемся на части волшебном мире любовь и верность проверяются на прочность, а конфликт разделяет даже настоящих друзей и членов семей.",
                          backImg = "https://pioner-cinema.ru/wp-content/uploads/2018/10/pioner-cinema.ru_e3c1712ed50fca219faeb2d1c1a889d7.jpg",
                          youtube = "https://www.youtube.com/watch?v=TwvJe2VwhTU",
                          statDate = new DateTime(2018, 12, 23),
                          endDate = new DateTime(2019, 01, 03),
                          id = 1,
                          sessions = new List<TimeSpan>()
                                      {
                                        new TimeSpan(11, 45, 0),
                                        new TimeSpan(17, 30, 0),
                                        new TimeSpan(22, 00, 0)
                                      },
                      }
                  );

            _listMockMovie.Add
                (new MockMovie
                    {
                        poster = "https://cinema.moscow/system/uploads/cover/image/8215/470178.jpg",
                        name = "Аквамен",
                        year = "США, 2018",
                        genre = "Фантастика, боевик, приключения",
                        director = "Джеймс Ван",
                        cast = "Джейсон Момоа, Ембер Герд, Патрік Вілсон, Віллем Дефо, Ніколь Кідман, Рендалл Парк, Дольф Лундгрен",
                        duration = "144 мин.",
                        about = "Артур Карри (звезда «Игры престолов» Джейсон Момоа) считал, что он сын простого смотрителя маяка. Но однажды мать открыла ему правду: он — наследник престола фантастического подводного царства, и в будущем ему суждено стать правителем семи морей. Вместе с дерзкой рыжеволосой подругой Мерой Артур отправляется на поиски легендарного магического трезубца, который поможет победить зловещего тирана Орма и стать не только королем Атлантиды, но и настоящим героем двух миров — земли и воды.",
                        backImg = "https://pioner-cinema.ru/wp-content/uploads/2018/12/pioner-cinema.ru_133a6119cd6fc27f4047a5c4f8e6ac86.jpg",
                        youtube = "https://www.youtube.com/watch?time_continue=57&v=fVDfuFL-QnY",
                        statDate = new DateTime(2018, 12, 13),
                        endDate = new DateTime(2019, 01, 09),
                        sessions = new List<TimeSpan>()
                                          {
                                            new TimeSpan(10, 00, 0),
                                            new TimeSpan(14, 30, 0),
                                            new TimeSpan(20, 00, 0)
                                          },
                        id = 2
                    }
                );

            _listMockMovie.Add
                (new MockMovie
                    {
                        poster = "https://cinema.moscow/system/uploads/cover/image/8223/738499.jpg",
                        name = "Гринч",
                        year = "США, 2018",
                        genre = "Мультфильм",
                        director = "Ярроу Чейни, Скотт Моужер",
                        cast = "Бенедикт Камбербэтч, Кэмерон Сили, Рашида Джонс, Фаррелл Уильямс, Tristan O'Hare, Кенан Томпсон, Сэм Лаваньино, Рамон Хэмилтон, Анджела Лэнсбери, Скарлет Эстевез.",
                        duration = "90 мин.",
                        about = "Гринч — самый настоящий интроверт. Он живет один в пещере на самой вершине горы, подальше от шумных соседей. Но каждый год их бурная подготовка к Новому году все равно добирается до его глаз и ушей. И страшно выводит из себя! Когда соседи объявляют, что в этом году празднование будет в три раза грандиознее, чем раньше, Гринч понимает: у него есть только один способ их остановить. И тогда он решает провернуть преступление века — украсть Новый год!",
                        backImg = "https://pioner-cinema.ru/wp-content/uploads/2018/12/pioner-cinema.ru_d236a663aa4de877fcc7623f909690a6.jpeg",
                        youtube = "https://www.youtube.com/watch?v=x0Q8jC6aVLI",
                        statDate = new DateTime(2018, 12, 20),
                        endDate = new DateTime(2019, 01, 16),
                        sessions = new List<TimeSpan>()
                                              {
                                                new TimeSpan(10, 15, 0),
                                                new TimeSpan(13, 40, 0),
                                                new TimeSpan(19, 30, 0)
                                              },
                        id = 3
                    }
                );
        }

        public  List<MockMovie> GetListMockMovie()
        {
            return _listMockMovie;
        }
    }

    public class MockMovie
    {
        public string poster { get; set; }

        public string name { get; set; }

        public string year { get; set; }

        public string genre { get; set; }

        public string director { get; set; }

        public string cast { get; set; }

        public string duration { get; set; }

        public string about { get; set; }

        public string backImg { get; set; }

        public string youtube { get; set; }

        public DateTime statDate { get; set; }

        public DateTime endDate { get; set; }

        public List<TimeSpan> sessions { get; set; }

        public int id { get; set; }
    }
    
}
