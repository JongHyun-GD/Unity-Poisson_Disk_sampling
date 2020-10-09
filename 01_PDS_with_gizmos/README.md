# Gizmos 수준에서 Simple Poisson Disk Sampling 구현

## 개요

- Poisson Disk Sampling의 결과를 Unity 내부 Gizmos를 통해 시각화 한다.
- ![capture](https://user-images.githubusercontent.com/58730856/95547448-fedb4d80-0a3d-11eb-9a1a-c16a7d908130.gif)


## Poisson Disk Sampling 알고리즘 요약



1. 랜덤한 포인트를 하나 설정한다.
2. 이 포인트를 두 개의 리스트(output, process)에 넣는다.

> output = 결과적으로 렌더링될 point의 집합

> process = 아직 PDS 알고리즘에 의해 주변 point를 계산하지 않은 point의 집합

3. process가 빌 때까지

> 주변에 minRange~maxRange 사이에 point를 k 선정한다.

> 선택된 point가 주변에 점이 없다면 최종적으로 output과 process 리스트에 넣는다.

> > (주변에 점을 확인하는 과정을 간단하게 하기 위해서 해당 그리드의 주변 9개만을 탐색하도록 했다.)



## Unity Project 요약

- CustomEditor를 통해 인게임에서 PDS를 여러번할 수 있도록 구현했다.

- 빨간 점이 샘플링된 좌표를 의미한다. 



## Reference

- http://devmag.org.za/2009/05/03/poisson-disk-sampling/
