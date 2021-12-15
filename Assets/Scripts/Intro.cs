using UnityEngine;

public class Intro : MonoBehaviour
{
  private ChuckSubInstance _chuck;

  private void Awake()
  {
    _chuck = GetComponent<ChuckSubInstance>();
  }

  private void Start()
  {
    _chuck.RunCode(@"
      SinOsc so => dac;

      1::second => now;
    ");
  }

  void Update()
  {
    // do nothing
  }
}
