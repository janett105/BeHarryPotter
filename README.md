# BeHarryPotter

## Voice Command(박지후)
Oculus voice SDK with Wit.ai

Wit.ai 
https://wit.ai/apps/184718221171935/understanding

### 구현 기능
1. **Wit Activation(scripit)** : event(Axis1D.SecondaryHandTrigger,Unity Axis ID-12)에 따른 음성 인식 시작/종료 
3. **VisualFeedback** :  Wit event(시작, 종료, 처리 중, 버튼 안 누르고 있을 때, 에러) 사용자에게 보여주는 text canvas
4. **Wit.ai training** : 

  * Immobulus - freeze(고드름 발사)
  * protego - defense(방어by 팔토시)
  * Incendio - flame(화염 방사)
 
4. **Response Handler** : 음성인식 결과(intent)가 training한 값에 있다면 Magic Handler에 intent 전달   
5. **Magic Handler(script)** : 음성인식 결과(intent)와 모션인식 결과(?)가 정답과 일치한다면 마법 실행

### 참고 자료
https://developer.oculus.com/documentation/unity/voice-sdk-overview/

https://github.com/wit-ai/wit-unity

https://www.youtube.com/watch?v=SJ96P-ZhBoc&themeRefresh=1

![image](https://github.com/ImmersiveContentsTeam1/BeHarryPotter/assets/81574359/ea1daac2-dd64-427c-a56d-8d866db5094e)

## Bhaptics(박지후)
Tactsuit X40

Bhaptics developer portal
https://developer.bhaptics.com/application/S7To1fRZxc79JUkIQoPn

* 주의 사항 : This is DontDestroyOnLoad, so you only need to put it in the first scene.

### 참고 자료
https://bhaptics.notion.site/Plug-in-deployed-events-to-Unity-33cc33dcfa44426899a3f21c62adf66d

https://github.com/bhaptics/haptic-guide

## Magic Wand 3D printing
3D printing model
https://www.thingiverse.com/thing:1069671

## Thermal Haptics - Arm Sleeve(채윤지) 
ardunity

## 오류
warning: LF will be replaced by CRLF in bora.txt.
The file will have its original line endings in your working directory
```
git config --global core.autocrlf true
```

## BeHarryPotter Game (Unity3D) (이은화)
with Oculus Quest 2

VR로 마법 전투 게임을 구현하였다. 

적은 플레이어를 추적한 후 공격 반경에 들어오면 적을 마법으로 공격한다. 

일반 공격과 불 공격이 있다. 

플레이어는 마법으로 적을 무찌를 수 있도록 개발하였다. 

https://answers.unity.com/questions/785746/anyway-to-tell-which-side-of-a-collider-is-hit.html
