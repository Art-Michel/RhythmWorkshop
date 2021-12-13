using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.IO;
using System.Linq;

public class SoundManagerCreator : EditorWindow
{
    private string _sfxPath = "SFX";
    private string _soundManagerPath = "Scripts/SoundManager.cs";
    private string _soundManagerTempaltePath = "Editor/SoundManagerCreator/SoundManagerTemplate.txt";
    private List<string> _sfxPathList = null;

    [MenuItem("Window/SoundManagerCreator")]
    public static void ShowWindow()
    {
        EditorWindow.GetWindow(typeof(SoundManagerCreator));
    }

    private void OnEnable()
    {
        _sfxPathList = GetAllSoundFiles(Application.dataPath + "\\" + _sfxPath, new List<string>());
    }

    private void OnGUI()
    {
        _sfxPath = EditorGUILayout.TextField("SFX folder path :", _sfxPath);
        _soundManagerPath = EditorGUILayout.TextField("Sound manager path :", _soundManagerPath);
        _soundManagerTempaltePath = EditorGUILayout.TextField("Sound manager template path :", _soundManagerTempaltePath);

        if (GUILayout.Button("Refresh sfx paths"))
            _sfxPathList = GetAllSoundFiles(Application.dataPath + "\\" + _sfxPath, new List<string>());

        if (GUILayout.Button("Generate sound manager"))
        {
            GenerateSoundManager();
            FillSoundManager();
        }
        _sfxPathList.ForEach(sfxPath => GUILayout.Label(sfxPath));
    }

    private List<string> GetAllSoundFiles(string directoryPath, List<string> sfxPathList)
    {
        string[] filesPaths = Directory.GetFiles(directoryPath);

        for (int i = 0; i < filesPaths.Length; i++)
        {
            if (filesPaths[i].Split('.').Last() == "wav")
                sfxPathList.Add(filesPaths[i].Replace('/', '\\'));
        }

        string[] subDirectoriesPaths = Directory.GetDirectories(directoryPath);

        for (int y = 0; y < subDirectoriesPaths.Length; y++)
        {
            sfxPathList = GetAllSoundFiles(subDirectoriesPaths[y], sfxPathList);
        }

        return sfxPathList;
    }

    private void GenerateSoundManager()
    {
        string soundManagerTemplate = GetCutTemplate();

        for (int i = 0; i < _sfxPathList.Count; i++)
        {
            soundManagerTemplate += CreateSfxFunction(_sfxPathList[i], i);
        }

        soundManagerTemplate += "\n}";
        File.WriteAllText(Application.dataPath + "\\" + _soundManagerPath, soundManagerTemplate);
        AssetDatabase.Refresh();
    }

    private string GetCutTemplate()
    {
        string soundManagerTemplate = File.ReadAllText(Application.dataPath + "\\" + _soundManagerTempaltePath);
        string[] splitTemplate = soundManagerTemplate.Split('}');

        string cutSoundManagerTemplate = splitTemplate[0] + "}" + splitTemplate[1] + "}";

        return cutSoundManagerTemplate;
    }

    private string CreateSfxFunction(string sfxPath, int index)
    {
        string sfxFunction = "\n\n\tpublic void Play";
        sfxFunction += GetClipName(sfxPath);
        sfxFunction += "()";
        sfxFunction += "\n\t{\n\t\tPlay(";
        sfxFunction += "clips[" + index + "]);\n\t}";

        return sfxFunction;
    }

    private string GetClipName(string sfxPath)
    {
        return sfxPath.Split('\\').Last().Split('.').First();
    }

    private string GetLowerClipName(string sfxPath)
    {
        string clipName = GetClipName(sfxPath);
        return string.Concat((char)(clipName[0] + 32), clipName.Substring(1, clipName.Length - 1));
    }

    private void FillSoundManager()
    {
        List<GameObject> sceneGameObjects = new List<GameObject>(SceneManager.GetActiveScene().GetRootGameObjects());
        SoundManager soundManager = sceneGameObjects.Find(gameObject => gameObject.name == "SoundManager").GetComponent<SoundManager>();

        soundManager.clips = new List<AudioClip>();
        _sfxPathList.ForEach(sfxPath =>
        {
            soundManager.clips.Add(AssetDatabase.LoadAssetAtPath(GetPathFromAssets(sfxPath), typeof(AudioClip)) as AudioClip);
        });
    }

    private string GetPathFromAssets(string path)
    {
        string pathFromAssets = "";
        string[] splitPath = path.Split('\\');
        bool startConcat = false;

        for (int i = 0; i < splitPath.Length; i++)
        {
            if (startConcat || splitPath[i] == "Assets")
            {
                startConcat = true;
                pathFromAssets += splitPath[i];
                if (i != splitPath.Length - 1)
                    pathFromAssets += '/';
            }
        }
        return pathFromAssets;
    }
}
