# Become A Wizard
다양한 하드웨어를 사용해 실감있는 마법 공격/방어 구현
현재 일정 수준 이상의 시청각 경험 제공되어 있는 반면에 그 이외의 경험 제공은 미비하다는 한계 존재

## Experience
1. Voice Interaction : 음성으로 마법주문을 외쳐서 적을 공격/방어 with wit.ai 
2. Temperature : 적의 불 공격을 맞았을 때 목에 뜨거움 with peltier
3. Vibration : 적의 공격을 맞았을 때 느끼는 몸의 진동 with Bhaptics
4. Resistance : 지팡이를 휘두를 때 느끼는 바람저항 with 3D printer
   
## Voice Interaction
Oculus voice SDK with Wit.ai
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

## Bhaptics
Tactsuit X40

Bhaptics developer portal
https://developer.bhaptics.com/application/S7To1fRZxc79JUkIQoPn

* 주의 사항 : This is DontDestroyOnLoad, so you only need to put it in the first scene.

### 참고 자료
https://bhaptics.notion.site/Plug-in-deployed-events-to-Unity-33cc33dcfa44426899a3f21c62adf66d

https://github.com/bhaptics/haptic-guide

## Magic Wand 3D printing
3D printing model
use z-suite software
https://www.thingiverse.com/thing:1069671

## Thermal Haptics - Arm Sleeve 
ardunity
arduino and l298n with peltier
make peltier hot and cold when user didn't defend attack
https://deneb21.tistory.com/281

## BeHarryPotter Game (Unity3D)
with Oculus Quest 2

VR로 마법 전투 게임을 구현하였다. 

적은 플레이어를 추적한 후 공격 반경에 들어오면 적을 마법으로 공격한다. 

일반 공격과 불 공격이 있다. 

플레이어는 마법으로 적을 무찌를 수 있도록 개발하였다.

### 구현 기능
1. **Player.cs** : player collider 충돌 감지 후, 공격Type+충돌 방향+방어 성공 여부 따라, bhaptics(attacked) or sleeve(defense) signal
2. **Magic Attack.cs** : 


#### 오류
1. warning: LF will be replaced by CRLF in bora.txt. The file will have its original line endings in your working directory
```
git config --global core.autocrlf true
```

2. .gitignore 문제
https://stackoverflow.com/questions/32783295/unity-git-ignore-library




