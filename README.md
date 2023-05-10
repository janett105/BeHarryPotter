# BeHarryPotter

## Voice Command(박지후)
Oculus voice SDK with Wit.ai

Wit.ai 
https://wit.ai/apps/184718221171935/understanding

### 구현 기능
1. **Wit Activation(scripit)** : event(wand button click)에 따른 음성 인식 시작/종료 (현재는 space bar)
2. **VisualFeedback** :  Wit event(시작, 종료, 처리 중, 버튼 안 누르고 있을 때, 에러) 사용자에게 보여주는 text canvas
3. **Wit.ai training** : 

  * Wingardium Leviosa - levitate(띄우기) 
  * 스튜티파이 - 찌르기 
  * Incendio - flame(화염 방사)
4. **Response Handler** : 음성인식 결과가 training한 값에 있다면 value에 저장, Magic Handler에 value 전달   
4. **Magic Handler(script)** : 음성인식 결과(intent)와 모션인식 결과(?)가 정답과 일치한다면 마법 실행

### 참고 자료
https://developer.oculus.com/documentation/unity/voice-sdk-overview/

https://github.com/wit-ai/wit-unity

https://www.youtube.com/watch?v=SJ96P-ZhBoc&themeRefresh=1
