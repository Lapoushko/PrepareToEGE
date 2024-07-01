using UnityEngine;
using YG;

/// <summary>
/// Сохранения 
/// </summary>
public class SaveDataImpl : MonoBehaviour, SaveData, LoadData, DeleteData
{
    public static SaveDataImpl instance;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
            return;
        }
    }

    public StateCourse LoadSaveCloudDict(string name)
    {
        float[] array = new float[3];
        int id = 0;
        if (name == NamesCourses.Math)
        {
            array[0] = YandexGame.savesData.mathDataStamina;
            array[1] = YandexGame.savesData.mathDataMotivation;
            array[2] = YandexGame.savesData.mathDataProgress;
        }
        else if (name == NamesCourses.Russian)
        {
            array[0] = YandexGame.savesData.russianDataStamina;
            array[1] = YandexGame.savesData.russianDataMotivation;
            array[2] = YandexGame.savesData.russianDataProgress;
        }
        else if (name == NamesCourses.Info)
        {
            array[0] = YandexGame.savesData.infoDataStamina;
            array[1] = YandexGame.savesData.infoDataMotivation;
            array[2] = YandexGame.savesData.infoDataProgress;
        }
        StateCourse course = new StateCourse(false, name, array[0], array[1], array[2]);
        return course;
    }


    public int LoadSaveCloudInt()
    {
        Debug.Log(YandexGame.savesData.countDay);
        return YandexGame.savesData.countDay;
    }

    public void Save(StateCourse course)
    {
        int id = 0;
        if (course.Name == NamesCourses.Math)
        {
            id = 0;
            YandexGame.savesData.mathDataStamina = course.Stamina;
            YandexGame.savesData.mathDataMotivation = course.Motivation;
            YandexGame.savesData.mathDataProgress = course.Progress;
        }
        else if (course.Name == NamesCourses.Russian)
        {
            id = 1;
            YandexGame.savesData.russianDataStamina = course.Stamina;
            YandexGame.savesData.russianDataMotivation = course.Motivation;
            YandexGame.savesData.russianDataProgress = course.Progress;
        }
        else if (course.Name == NamesCourses.Info)
        {
            id = 2;
            YandexGame.savesData.infoDataStamina = course.Stamina;
            YandexGame.savesData.infoDataMotivation = course.Motivation;
            YandexGame.savesData.infoDataProgress = course.Progress;
        }
        YandexGame.SaveProgress();
    }

    public void Save(int countDay)
    {
        YandexGame.savesData.countDay = countDay;
        YandexGame.SaveProgress();
        Debug.Log(YandexGame.savesData.countDay);
    }

    public void DeleteData()
    {  
        YandexGame.ResetSaveProgress();
    }

    public void Save(float score)
    {      
        YandexGame.NewLeaderboardScores("Highscore", (int)score);
        YandexGame.SaveProgress();
    }
}

/// <summary>
/// Сохранение
/// </summary>
interface SaveData
{
    /// <summary>
    /// Сохранение курсов
    /// </summary>
    /// <param name="dict">курсы</param>
    void Save(StateCourse course);

    /// <summary>
    /// Сохранение количества дней
    /// </summary>
    /// <param name="countDay">количество дней</param>
    void Save(int countDay);

    /// <summary>
    /// Сохранение максимального значения
    /// </summary>
    /// <param name="score">количество очков</param>
    void Save(float score);
}

interface LoadData
{
    /// <summary>
    /// Загрузка данных курсов
    /// </summary>
    /// <returns>курсы</returns>
    StateCourse LoadSaveCloudDict(string name);

    /// <summary>
    /// Загрузка данных количества дней
    /// </summary>
    /// <returns>количество дней</returns>
    int LoadSaveCloudInt();
}

interface DeleteData
{
    /// <summary>
    /// Удалить данные
    /// </summary>
    void DeleteData();
}
