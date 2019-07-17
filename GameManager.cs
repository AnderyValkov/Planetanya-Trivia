using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;
using System.IO;
using Newtonsoft.Json;

public class GameManager : MonoBehaviour
{
    public Button selectRussian, selectEngligh, selectHebrew;
    enum Difficulty {Easy,Medium,Hard }
    string path = Application.dataPath + "/StreamingAssets/Saves";

    #region Internal Classes
    class Question
    {
        public Difficulty difficulty;
        public Dictionary<string, bool> answer;
        public string desctiption;
        public string clue;
    }

    [Serializable]
    class Game
    {
        public string hiddenWord;
        public Difficulty gameDifficulty;
        public List<Question> questions;
        public Game()
        {
            questions = new List<Question>();
        }
    }



    #endregion

    #region DefaultGames
    Game CreateDefaultGameEnglish()//done
    {
        //Setting for the chosen game
        Game gameEnglish = new Game();
        gameEnglish.hiddenWord = "Proxima-Centauri";
        gameEnglish.gameDifficulty = Difficulty.Medium;
        Question []question = new Question[16];

        //Building the questions themselves
        question[0].desctiption = "Who was the first man in space?";
        question[0].clue = "The statue outside is dedicated to him";
        question[0].difficulty = Difficulty.Hard;
        question[0].answer.Add("Buzz Aldrin", false);
        question[0].answer.Add("Sally Ride", false);
        question[0].answer.Add("Yuri Gagarin", true);
        question[0].answer.Add("Buzz Lightyear", false);
        question[0].answer.Add("Valentina Tereshkova", false);
        question[0].answer.Add("Neil Armstrong", false);

        question[1].desctiption = "Which planet is the hottest in the solar system?";
        question[1].clue = "It's named after the roman goddess of love";
        question[1].difficulty = Difficulty.Medium;
        question[1].answer.Add("The Earth",false);
        question[1].answer.Add("Mercury", false);
        question[1].answer.Add("The Sun", false);
        question[1].answer.Add("Venus", true);
        question[1].answer.Add("Mars", false);
        question[1].answer.Add("Jupiter", false);

        question[2].desctiption = "Which planet is the biggest in the solar system?";
        question[2].clue = "Named after the roman king of gods";
        question[2].difficulty = Difficulty.Easy;
        question[2].answer.Add("Jupiter",true);
        question[2].answer.Add("The Sun", false);
        question[2].answer.Add("The earth", false);
        question[2].answer.Add("Saturn", false);
        question[2].answer.Add("Mercury", false);
        question[2].answer.Add("Planet X", false);

        question[3].desctiption = "How many moons does mars have?";
        question[3].clue = "Twice the number of eyes a cyclops has";
        question[3].difficulty = Difficulty.Hard;
        question[3].answer.Add("12",false);
        question[3].answer.Add("1",false);
        question[3].answer.Add("0",false);
        question[3].answer.Add("10",false);
        question[3].answer.Add("2",true);
        question[3].answer.Add("42",false);

        question[4].desctiption = "Who was the second man on the moon?";
        question[4].clue = "Buzz Lightyear is named after him";
        question[4].difficulty = Difficulty.Medium;
        question[4].answer.Add("Neil Armstrong", false);
        question[4].answer.Add("Laika the dog", false);
        question[4].answer.Add("Buzz Aldrin", true);
        question[4].answer.Add("Buzz Lightyear", false);
        question[4].answer.Add("Ilan Ramon", false);
        question[4].answer.Add("Yuri Gagarin", false);

        question[5].desctiption = "What is the brightest star in the night sky?";
        question[5].clue = "It's SERIOUSly bright.";
        question[5].difficulty = Difficulty.Hard;
        question[5].answer.Add("Sirius", true);
        question[5].answer.Add("Aldebaran", false);
        question[5].answer.Add("Orion", false);
        question[5].answer.Add("Polaris", false);
        question[5].answer.Add("Deneb", false);
        question[5].answer.Add("Altair", false);

        question[6].desctiption = "What star stays in the same spot all the time?";
        question[6].clue = "The star you can always see in the north";
        question[6].difficulty = Difficulty.Hard;
        question[6].answer.Add("Vega", false);
        question[6].answer.Add("Mizar", false);
        question[6].answer.Add("Alhpa Centauri", false);
        question[6].answer.Add("The sun", false);
        question[6].answer.Add("Antares", false);
        question[6].answer.Add("Polaris", true);

        question[7].desctiption = "How many planets do we have in the solar system?";
        question[7].clue = "If there was a big enough octopus, it could hold them";
        question[7].difficulty = Difficulty.Easy;
        question[7].answer.Add("13", false);
        question[7].answer.Add("7", false);
        question[7].answer.Add("8", true);
        question[7].answer.Add("5", false);
        question[7].answer.Add("more than 100", false);
        question[7].answer.Add("9", false);

        question[8].desctiption = "How many dwarf planets do we have in the solar system?";
        question[8].clue = "You could count them on one hand";
        question[8].difficulty = Difficulty.Hard;
        question[8].answer.Add("8", false);
        question[8].answer.Add("11", false);
        question[8].answer.Add("1", false);
        question[8].answer.Add("3", false);
        question[8].answer.Add("5", true);
        question[8].answer.Add("9", false);

        question[9].desctiption = "What is the closest planet to the sun?";
        question[9].clue = "Named after the roman messanger of the gods";
        question[9].difficulty = Difficulty.Medium;
        question[9].answer.Add("Mecury", true);
        question[9].answer.Add("Venus", false);
        question[9].answer.Add("Mars", false);
        question[9].answer.Add("Earth", false);
        question[9].answer.Add("Jupiter", false);
        question[9].answer.Add("Uranus", false);

        question[10].desctiption = "How long does it take the moon to orbit the earth?";
        question[10].clue = "Same as it takes it to get the same shape";
        question[10].difficulty = Difficulty.Easy;
        question[10].answer.Add("One day", false);
        question[10].answer.Add("two weeks", false);
        question[10].answer.Add("A month", true);
        question[10].answer.Add("A year", false);
        question[10].answer.Add("The moon is not real", false);
        question[10].answer.Add("Two days", false);

        question[11].desctiption = "How long is a day on venus?";
        question[11].clue = "About as long as it's year";
        question[11].difficulty = Difficulty.Hard;
        question[11].answer.Add("1 earth days", false);
        question[11].answer.Add("Half an earth day", false);
        question[11].answer.Add("243 earth days", true);
        question[11].answer.Add("116 earth days", false);
        question[11].answer.Add("48 hours", false);
        question[11].answer.Add("10 hours", false);

        question[12].desctiption = "What is a supernova?";
        question[12].clue = "You don't want to be close to one";
        question[12].difficulty = Difficulty.Medium;
        question[12].answer.Add("An explosion caused by the death of a massive star.", true);
        question[12].answer.Add("A bright spark resuletd by the birth of a new star", false);
        question[12].answer.Add("A super massive black hole", false);
        question[12].answer.Add("A very big star", false);
        question[12].answer.Add("The death of a planet", false);
        question[12].answer.Add("A red giant", false);

        question[13].desctiption = "What is the name of the closest galaxy to the milky way";
        question[13].clue = "Named after the wife of Perseus";
        question[13].difficulty = Difficulty.Medium;
        question[13].answer.Add("Sombrero Galaxy", false);
        question[13].answer.Add("Egg Galaxy", false);
        question[13].answer.Add("Hamburger Galaxy", false);
        question[13].answer.Add("Whale Galaxy", false);
        question[13].answer.Add("Pinwheel Galaxy", false);
        question[13].answer.Add("Andromeda Galaxy", true);

        question[14].desctiption = "What does a light year measure?";
        question[14].clue = "The speed of light times a eyar equals what?";
        question[14].difficulty = Difficulty.Medium;
        question[14].answer.Add("Mass", false);
        question[14].answer.Add("Temprature", false);
        question[14].answer.Add("Brightness", false);
        question[14].answer.Add("Weight", false);
        question[14].answer.Add("Time", false);
        question[14].answer.Add("Distance", true);

        question[15].desctiption = "What is the dark side of the moon?";
        question[15].clue = "You can never see it from earth";
        question[15].difficulty = Difficulty.Medium;
        question[15].answer.Add("A coder region of the moon", false);
        question[15].answer.Add("A side that never sees sunlight", false);
        question[15].answer.Add("A name for the dark areas on the moon", false);
        question[15].answer.Add("A Pink Floyd Album", true);
        question[15].answer.Add("The far side of the moon", true);
        question[15].answer.Add("The side we see of the moon", false);

        foreach(Question que in question)
            gameEnglish.questions.Add(que);
        
        return gameEnglish;
    }

    Game CreateDefaultGameHebrew()//done
    {
        Game gameHebrew = new Game();
        gameHebrew.hiddenWord = flipText("פרוקסימה-קנטאורי");//will probably write this from right to left
        gameHebrew.gameDifficulty = Difficulty.Medium;
        Question[] question = new Question[16];

        question[0].desctiption= flipText("מי האדם הראשון בחלל?");
        question[0].clue = flipText("יש פסל שלו בחוץ");
        question[0].difficulty = Difficulty.Medium;
        question[0].answer.Add(flipText("ניל ארמסטרונג"), false);
        question[0].answer.Add(flipText("גלילאו גלילאי"), false);
        question[0].answer.Add(flipText("באז אולדרין"), false);
        question[0].answer.Add(flipText("אילן רמון"), false);
        question[0].answer.Add(flipText("באז שנות אור"), false);
        question[0].answer.Add(flipText("יורי גגרין"), true);

        question[1].desctiption = flipText("מי כוכב הלכת החם ביותר במערכת השמש?");
        question[1].clue = flipText("קרוי על שם אלת  היופי והאהבה הרומית");
        question[1].difficulty = Difficulty.Hard;
        question[1].answer.Add(flipText("חמה"), false);
        question[1].answer.Add(flipText("מאדים"), false);
        question[1].answer.Add(flipText("צדק"), false);
        question[1].answer.Add(flipText("נוגה"), true);
        question[1].answer.Add(flipText("השמש"), false);
        question[1].answer.Add(flipText("מרקורי"), false);

        question[2].desctiption = flipText("כמה כוכבי לכת יש במערכת השמש?");
        question[2].clue = flipText("אם היה תמנון מספיק גדול הוא היה יכול להחזיק את כולם");
        question[2].difficulty = Difficulty.Easy;
        question[2].answer.Add(flipText("9"), false);
        question[2].answer.Add(flipText("13"), false);
        question[2].answer.Add(flipText("5"), false);
        question[2].answer.Add(flipText("8"), true);
        question[2].answer.Add(flipText("7"), false);
        question[2].answer.Add(flipText("11"), false);

        question[3].desctiption = flipText("איך קראו למעבורת החלל שבה היה אילן רמון?");
        question[3].clue = flipText("קרוי על שם מדינה בדרום אמריקה");
        question[3].difficulty = Difficulty.Medium;
        question[3].answer.Add(flipText("קולומביה"), true);
        question[3].answer.Add(flipText("בראשית"), false);
        question[3].answer.Add(flipText("סויוז"), false);
        question[3].answer.Add(flipText("פלקון 11"), false);
        question[3].answer.Add(flipText("אפולו"), false);
        question[3].answer.Add(flipText("ווסטוק"), false);

        question[4].desctiption = flipText("כמה כוכבי לכת ננסיים יש במחרכת השמש?");
        question[4].clue = flipText("אפשר לספור אותם על יד אחת");
        question[4].difficulty = Difficulty.Hard;
        question[4].answer.Add(flipText("5"), true);
        question[4].answer.Add(flipText("8"), false);
        question[4].answer.Add(flipText("9"), false);
        question[4].answer.Add(flipText("3"), false);
        question[4].answer.Add(flipText("11"), false);
        question[4].answer.Add(flipText("1"), false);

        question[5].desctiption = flipText("מי היה האדם השני על הירח?");
        question[5].clue = flipText("הדמות של באז שנות אור מבוסס עליו");
        question[5].difficulty = Difficulty.Medium;
        question[5].answer.Add(flipText("יורי גגרין"), false);
        question[5].answer.Add(flipText("ניל ארמסטרונג"), false);
        question[5].answer.Add(flipText("מייקל קולינס"), false);
        question[5].answer.Add(flipText("אלן שפרד"), false);
        question[5].answer.Add(flipText("באז שנות אור"), false);
        question[5].answer.Add(flipText("באז אולדרין"), true);

        question[6].desctiption = flipText("מי יותר גדול?");
        question[6].clue = flipText("זה המקום הכי חם מההבאים");
        question[6].difficulty = Difficulty.Hard;
        question[6].answer.Add(flipText("רוסיה"), true);
        question[6].answer.Add(flipText("כוכב הלכת הננסי פלוטו"), false);
        question[6].answer.Add(flipText("הירח טיטניה "), false);
        question[6].answer.Add(flipText("אנטארקטיקה"), false);
        question[6].answer.Add(flipText("כוכב הלכת הננסי האומיה"), false);
        question[6].answer.Add(flipText("הירח אנקלדוס"), false);

        question[7].desctiption = flipText("למי מההבאים אין טבעות?");
        question[7].clue = flipText("היחידי שאפשר לדרוך עליו");
        question[7].difficulty = Difficulty.Hard;
        question[7].answer.Add(flipText("נפטון"), false);
        question[7].answer.Add(flipText("שבתאי"), false);
        question[7].answer.Add(flipText("צדק"), false);
        question[7].answer.Add(flipText("אורנוס"), false);
        question[7].answer.Add(flipText("מאדים"), true);
        question[7].answer.Add(flipText("רהב"), false);

        question[8].desctiption = flipText("כמה ירחים יש למאדים?");
        question[8].clue = flipText("יש לאדם הממוצע מספיק ידיים להחזיק אותם");
        question[8].difficulty = Difficulty.Medium;
        question[8].answer.Add(flipText("2"), true);
        question[8].answer.Add(flipText("42"), false);
        question[8].answer.Add(flipText("1"), false);
        question[8].answer.Add(flipText("0"), false);
        question[8].answer.Add(flipText("10"), false);
        question[8].answer.Add(flipText("100"), false);

        question[9].desctiption = flipText("מי הכוכב הכי זוהר בשמי הלילה?");
        question[9].clue = flipText("סיריוסלי?");
        question[9].difficulty = Difficulty.Hard;
        question[9].answer.Add(flipText("אלטאיר"), false);
        question[9].answer.Add(flipText("וגה"), false);
        question[9].answer.Add(flipText("אנטארס"), false);
        question[9].answer.Add(flipText("סיריוס"), true);
        question[9].answer.Add(flipText("אלדברן"), false);
        question[9].answer.Add(flipText("ספיקה"), false);

        question[10].desctiption = flipText("איזה כוכה נשאר תמיד באותו מקום?");
        question[10].clue = flipText("אפשר לארות אותו בחצי כדור הארץ הצפוני");
        question[10].difficulty = Difficulty.Easy;
        question[10].answer.Add(flipText("כוכב הצפון"), true);
        question[10].answer.Add(flipText("פרוקיון"), false);
        question[10].answer.Add(flipText("פולוקס"), false);
        question[10].answer.Add(flipText("קסטור"), false);
        question[10].answer.Add(flipText("קאפלה"), false);
        question[10].answer.Add(flipText("ארקטורוס"), false);

        question[11].desctiption = flipText("מה זה סופרנובה?");
        question[11].clue = flipText("מה שקורה לבלון שמתנפח יותר מידי");
        question[11].difficulty = Difficulty.Medium;
        question[11].answer.Add(flipText("הבזק אור חזק"), false);
        question[11].answer.Add(flipText("התנגשות של שני כוכבים"), false);
        question[11].answer.Add(flipText("לידה של כוכב חדש"), false);
        question[11].answer.Add(flipText("מוות של כוכב לכת"), false);
        question[11].answer.Add(flipText("התנפחות כוכב"), false);
        question[11].answer.Add(flipText("פיצוץ שנוצב ממוות של כוכב"), true);

        question[12].desctiption = flipText("איך קוראים לגלקסיה הגדולה הכי קרובה לשביל החלב?");
        question[12].clue = flipText("קרויה על שם אשתו של מי שהרג את מדוזה גורגונה");
        question[12].difficulty = Difficulty.Medium;
        question[12].answer.Add(flipText("גלקסית הסומבררו"), false);
        question[12].answer.Add(flipText("גלקסית אנדרומדה"), true);
        question[12].answer.Add(flipText("גלקסית ההמבורגר"), false);
        question[12].answer.Add(flipText("גלקסית הלוויתן"), false);
        question[12].answer.Add(flipText("גלקסית הסיגריה"), false);
        question[12].answer.Add(flipText("גלקסית השבשבת"), false);

        question[13].desctiption = flipText("מה ההבדל בין ככובי לכת ארציים וגזיים?");
        question[13].clue = flipText("אם תיכנסו לכוכב לכת גזי, לא תפסיקו ליפול");
        question[13].difficulty = Difficulty.Easy;
        question[13].answer.Add(flipText("על ארציים אפשר לעמוד בזמן שלגזיים אין קרקע"), true);
        question[13].answer.Add(flipText("כמות האטמוספירה שיש בהם"), false);
        question[13].answer.Add(flipText("הגודל"), false);
        question[13].answer.Add(flipText("רק על כוכבי לכת ארציים יש מים"), false);
        question[13].answer.Add(flipText("רק לכוכבי לכת גזים יש אטמוספירה"), false);
        question[13].answer.Add(flipText("לארציים רואים את הקרקע"), false);

        question[14].desctiption = flipText("איך קורים למקום בו נוצרים כוכבים וכוכבי לכת?");
        question[14].clue = flipText("בתוך סוג של ענן");
        question[14].difficulty = Difficulty.Medium;
        question[14].answer.Add(flipText("חורים שחורים"), false);
        question[14].answer.Add(flipText("ערפיליות"), true);
        question[14].answer.Add(flipText("צבירי כוכבים"), false);
        question[14].answer.Add(flipText("קבוצות כוכבים"), false);
        question[14].answer.Add(flipText("מערכות שמש"), false);
        question[14].answer.Add(flipText("ספרות דייסון"), false);

        question[15].desctiption = flipText("איזה כוכב  לכת זז הכי מהר סביב השמש?");
        question[15].clue = flipText("האחד הכי קרוב אליו");
        question[15].difficulty = Difficulty.Medium;
        question[15].answer.Add(flipText("מאדים"), false);
        question[15].answer.Add(flipText("צדק"), false);
        question[15].answer.Add(flipText("נוגה"), false);
        question[15].answer.Add(flipText("חמה"), true);
        question[15].answer.Add(flipText("נפטון"), false);
        question[15].answer.Add(flipText("כדור הארץ"), false);

        foreach (Question que in question)
            gameHebrew.questions.Add(que);

        return gameHebrew;
    }

    Game CreateDefaultGameRussian()
    {
        Game gameRussain = new Game();
        gameRussain.hiddenWord = "Проксима-Центавра";
        Question[] question = new Question[17];

        question[0].desctiption = "Кто был первым человеком в космосе?";
        question[0].clue = "Статуе в честь его находится у входа";
        question[0].difficulty = Difficulty.Easy;
        question[0].answer.Add("Базз Олдрин", false);
        question[0].answer.Add("Сали Райд", false);
        question[0].answer.Add("Юрий Гагарин", false);
        question[0].answer.Add("Валентина Терешкова", false);
        question[0].answer.Add("Базз Лайтер", false);
        question[0].answer.Add("Нил Армчтронг", false);

        question[1].desctiption = "Какая самая горячая планета в солярной системе?";
        question[1].clue = "Названа в честь римской богине любви";
        question[1].difficulty = Difficulty.Easy;
        question[1].answer.Add("Земля", false);
        question[1].answer.Add("Меркури", false);
        question[1].answer.Add("Солнце", false);
        question[1].answer.Add("Венера", false);
        question[1].answer.Add("Марс", false);
        question[1].answer.Add("Юпитер", false);

        question[2].desctiption = "Какая самая большая планета в солярной системе?";
        question[2].clue = "Названа в честь римского короля богов";
        question[2].difficulty = Difficulty.Easy;
        question[2].answer.Add("Юпитер", false);
        question[2].answer.Add("Солнце", false);
        question[2].answer.Add("Земля", false);
        question[2].answer.Add("Сатурн", false);
        question[2].answer.Add("Меркури", false);
        question[2].answer.Add("Планета X", false);

        question[3].desctiption = "Сколько лун у Марса?";
        question[3].clue = "В два раза больше чем у Циклопа глаз";
        question[3].difficulty = Difficulty.Easy;
        question[3].answer.Add("12", false);
        question[3].answer.Add("1", false);
        question[3].answer.Add("0", false);
        question[3].answer.Add("10", false);
        question[3].answer.Add("2", false);
        question[3].answer.Add("42", false);

        question[4].desctiption = "Кто был второй человек ступивший на луну?";
        question[4].clue = "Базз Лайтер был назван в его честь";
        question[4].difficulty = Difficulty.Easy;
        question[4].answer.Add("Нил Армчтронг", false);
        question[4].answer.Add("Собака Лайка", false);
        question[4].answer.Add("Баз Лайтер", false);
        question[4].answer.Add("Базз Лайтер", false);
        question[4].answer.Add("Илан Рамон", false);
        question[4].answer.Add("Юрий Гагарин", false);

        question[5].desctiption = "Какая самая яркая звезда на ночном небе?";
        question[5].clue = "Она СЕРЬЕЗНО яркая";
        question[5].difficulty = Difficulty.Easy;
        question[5].answer.Add("Сириус", false);
        question[5].answer.Add("Альдебаран", false);
        question[5].answer.Add("Орион", false);
        question[5].answer.Add("Полярная звезда", false);
        question[5].answer.Add("Денеб", false);
        question[5].answer.Add("Альтаир", false);

        question[6].desctiption = "Какая звезда всё время остается на одном месте?";
        question[6].clue = "Звезда, которую всегда можно увидеть на севере";
        question[6].difficulty = Difficulty.Easy;
        question[6].answer.Add("Вега", false);
        question[6].answer.Add("Мицар", false);
        question[6].answer.Add("Альфа Центавра", false);
        question[6].answer.Add("Солнце", false);
        question[6].answer.Add("Антарес", false);
        question[6].answer.Add("Полярная звезда", false);

        question[7].desctiption = "Сколько планет в солярной системе?";
        question[7].clue = "Если бы был достаточно большой осьминог, он мог бы удержать их всех";
        question[7].difficulty = Difficulty.Easy;
        question[7].answer.Add("13", false);
        question[7].answer.Add("7", false);
        question[7].answer.Add("8", false);
        question[7].answer.Add("5", false);
        question[7].answer.Add("больше чем 100", false);
        question[7].answer.Add("9", false);

        question[8].desctiption = "Сколько карликовых планет у нас в солнечной системе?";
        question[8].clue = "Можно их сошчитать на одной руке";
        question[8].difficulty = Difficulty.Easy;
        question[8].answer.Add("8", false);
        question[8].answer.Add("11", false);
        question[8].answer.Add("1", false);
        question[8].answer.Add("3", false);
        question[8].answer.Add("5", false);
        question[8].answer.Add("9", false);

        question[9].desctiption = "Какая планета ближе всего к солнцу?";
        question[9].clue = "Названа в честь римского посланника богов";
        question[9].difficulty = Difficulty.Easy;
        question[9].answer.Add("Меркури", false);
        question[9].answer.Add("Венера", false);
        question[9].answer.Add("Марс", false);
        question[9].answer.Add("Земля", false);
        question[9].answer.Add("Юпитер", false);
        question[9].answer.Add("Уран", false);

        question[10].desctiption = "Сколько времени занимает луне сделать оборот вокруг Земли?";
        question[10].clue = "Так же, как требуется ей, чтобы вернуться в ту же форму";
        question[10].difficulty = Difficulty.Easy;
        question[10].answer.Add("Один день", false);
        question[10].answer.Add("Две недели", false);
        question[10].answer.Add("Месяц", false);
        question[10].answer.Add("Год", false);
        question[10].answer.Add("Луна не настоящая", false);
        question[10].answer.Add("Два дня", false);

        question[11].desctiption = "Как долго длится день на венере?";
        question[11].clue = "Примерно столько же, сколькоъ год на ней";
        question[11].difficulty = Difficulty.Easy;
        question[11].answer.Add("Один день земли", false);
        question[11].answer.Add("Пол дня земли", false);
        question[11].answer.Add("243 дней земли", false);
        question[11].answer.Add("116 дней земли", false);
        question[11].answer.Add("48 часов", false);
        question[11].answer.Add("10 часов", false);

        question[12].desctiption = "Что это такое Супернова?";
        question[12].clue = "Вы бы не хочетели находиться рядом с одной";
        question[12].difficulty = Difficulty.Easy;
        question[12].answer.Add("Взрыв, вызванный гибелью массивной звезды", false);
        question[12].answer.Add("Яркая искра в результате рождения новой звезды", false);
        question[12].answer.Add("Сверхмассивная черная дыра", false);
        question[12].answer.Add("Очень большая звезда", false);
        question[12].answer.Add("Смерть планеты", false);
        question[12].answer.Add("Красный гигант", false);

        question[13].desctiption = "Как называется ближайшая к Млечному пути галактика?";
        question[13].clue = "Названа в честь жены Персея";
        question[13].difficulty = Difficulty.Easy;
        question[13].answer.Add("Галактика Сомбреро", false);
        question[13].answer.Add("Галактика шара", false);
        question[13].answer.Add("Галактика гамбургера", false);
        question[13].answer.Add("Галактика кита", false);
        question[13].answer.Add("Галактика цевочногр колеса", false);
        question[13].answer.Add("Галактика Андромеда", false);

        question[14].desctiption = "Что измеряет световой год?";
        question[14].clue = "Скорость света раз в год равна чему?";
        question[14].difficulty = Difficulty.Easy;
        question[14].answer.Add("Масса", false);
        question[14].answer.Add("Температура", false);
        question[14].answer.Add("Яркость", false);
        question[14].answer.Add("Вес", false);
        question[14].answer.Add("Время", false);
        question[14].answer.Add("Расстояние", false);

        question[15].desctiption = "Что такое темная сторона луны?";
        question[15].clue = "Вы никогда не сможете увидеть её с земли";
        question[15].difficulty = Difficulty.Easy;
        question[15].answer.Add("Кодер области луны", false);
        question[15].answer.Add("Сторона, которая никогда не видит солнечного света", false);
        question[15].answer.Add("Название для тёмных областей на луне", false);
        question[15].answer.Add("Альбом Pink Floyd", false);
        question[15].answer.Add("Дальняя сторона луны", false);
        question[15].answer.Add("Сторона луны, которую мы видим", false);

        question[16].desctiption = "";
        question[16].clue = "";
        question[16].difficulty = Difficulty.Easy;
        question[16].answer.Add("", false);
        question[16].answer.Add("", false);
        question[16].answer.Add("", false);
        question[16].answer.Add("", false);
        question[16].answer.Add("", false);
        question[16].answer.Add("", false);

        foreach (Question que in question)
            gameRussain.questions.Add(que);

        return gameRussain;
    }
    #endregion

    private void Start()
    {
        using (StreamWriter save = File.CreateText(path))
        {
            JsonSerializer serializer = new JsonSerializer();
            serializer.Serialize(save, CreateDefaultGameEnglish());
        }
    }

    string flipText(string Text)
    {
        char[] flippedText = new char[Text.Length];
        char[] originalText = Text.ToCharArray();
        for (int i = 0; i < Text.Length; i++)
        {
            flippedText[i] = originalText[originalText.Length - 1 - i];
        }
        return new string(flippedText);
        //return new string(originalText);
    }

}
