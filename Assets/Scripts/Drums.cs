using UnityEngine;

public class Drums : MonoBehaviour
{
  private const string _SoundName_Snare = "snare";
  private const string _SoundName_Kick = "kick";
  private const string _SoundName_HiHat = "hiHat";

  private ChuckSubInstance _chuck;

  private void Awake()
  {
    _chuck = GetComponent<ChuckSubInstance>();
  }

  private void Start()
  {
    if (!enabled)
    {
      return;
    }

    _chuck.RunCode($@"
      SndBuf snareSound => dac;
      SndBuf kickSound => dac;
      SndBuf hiHatSound => dac;

      while (true) {{
        me.dir() + ""sfx/{_SoundName_Kick}.wav"" => snareSound.read;
        snareSound.length() / snareSound.rate() => now;

        me.dir() + ""sfx/{_SoundName_Snare}.wav"" => kickSound.read;
        kickSound.length() / kickSound.rate() => now;

        me.dir() + ""sfx/{_SoundName_HiHat}.wav"" => hiHatSound.read;
        hiHatSound.length() / hiHatSound.rate() => now;
      }}
    ");
  }

  void Update()
  {
    // do nothing
  }
}
