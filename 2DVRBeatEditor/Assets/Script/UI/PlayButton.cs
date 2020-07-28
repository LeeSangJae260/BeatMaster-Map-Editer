using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using LS;
using LS.Arrival_Point;

//(노드 에디터) 음악 재생버튼 스크립트.
[RequireComponent (typeof(AudioSource))]
public class PlayButton : MonoBehaviour
{
    [SerializeField] Transform contents; //노드들을 담을 박스.
    [SerializeField] Transform item; //생성될 프리팹
    [SerializeField] float nordInterval = 0; //노드 간격
    [SerializeField] Sprite playImage; //플레이버튼 이미지(재생)
    [SerializeField] Sprite stopImage; //플레이버튼 이미지(정지)

    public AudioSource audioSource; // 음악소스 컴파일러
    Vector2 size; //노드타일 사이즈.

    int index = 0; 
    int playIndex = 0;
    float settingNord;
    float playNord;

    float interval;

    bool isPlaying = true; //음악 재생중인지를 확인할 변수
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        size = ArrivalPoint.GetPublicSize();

        interval = BPMComputation.GetBPM(nordInterval); //음악의 BPM 계산
    }

    public void Play()//재생버튼 트리거 함수
    {
        if (isPlaying)
        {
            audioSource.Play();
            GetComponent<Image>().sprite = stopImage;
            StartCoroutine("PlayMusicCoroutine");
        }
        else
        {
            audioSource.Pause();
            GetComponent<Image>().sprite = playImage;
            StopCoroutine("PlayMusicCoroutine");
        }
        isPlaying = !isPlaying;
    }

    public void newBeat()
    {
        StartCoroutine("BeatCoroutine");
    }

    public void LoadBeat()
    {
        StartCoroutine("LoadBeatCoroutine");
    }

    IEnumerator BeatCoroutine()//노드 생성 코루틴
    {
        Transform nord = Instantiate(item, item.position, Quaternion.identity); //노드 생성
        Nord nordScript = nord.GetComponent<Nord>(); //생성된 노드의 스크립트를 받음
        nord.SetParent(contents, false); //부모 설정
        nordScript.index = index; // 노드의 번호표를 설정
        nordScript.musicTime = settingNord; //음악의 위치 설정
        SaveToList.nordList.Add(nordScript.nord = new bool[(int)size.x, (int)size.y]); //해당 노드가 가지고있을 생성될 블럭의 정보
        ArrayNordTile.nordIntervals.Add(nordScript);
        
        index++;
        settingNord += interval;
        yield return null;
        if (audioSource.clip.length >= settingNord) //음악의 길이만큼 재귀
        {
            StartCoroutine(BeatCoroutine());
        }
    }

    IEnumerator LoadBeatCoroutine()//노드 생성 코루틴
    {
        Transform nord = Instantiate(item, item.position, Quaternion.identity); //노드 생성
        Nord nordScript = nord.GetComponent<Nord>(); //생성된 노드의 스크립트를 받음
        nord.SetParent(contents, false); //부모 설정
        nordScript.index = index; // 노드의 번호표를 설정
        nordScript.musicTime = settingNord; //음악의 위치 설정
        nordScript.nord = SaveToList.nordList[index];
        ArrayNordTile.nordIntervals.Add(nordScript);

        index++;
        settingNord += interval;
        yield return null;
        if (audioSource.clip.length >= settingNord) //음악의 길이만큼 재귀
        {
            StartCoroutine(BeatCoroutine());
        }
    }

    IEnumerator PlayMusicCoroutine()//음악 재생시 자동으로 다음 노드의 정보를 입력할 수 있게 해주는 코루틴
    {
        ArrayNordTile.nordIntervals[playIndex++].Click(); //해당 함수 실행
        playNord += interval;
        yield return new WaitForSeconds(interval);
        if (audioSource.clip.length >= playNord) //음악의 길이만큼 재귀
        {
            StartCoroutine("PlayMusicCoroutine");
        }
    }

    public void SetPlayNord(float i)
    {
        playNord = i;
    }

    public void SetPlayIndex(int i)
    {
        playIndex = i;
    }

    public AudioSource GetAudioSource()
    {
        return audioSource;
    }
}
