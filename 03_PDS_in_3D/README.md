# 3D World에서 3D 좌표를 통해 Simple Poisson Disk Sampling 구현

## 개요

- Poisson Disk Sampling을 3D 환경에서 구현한다.
- 3차원 극좌표계 중 구면좌표계를 통해 x,y,z 좌표를 구한다. 이 때, y 좌표가 up이다.
> ![03_capture](https://user-images.githubusercontent.com/58730856/97099981-49152d80-16d2-11eb-9d2d-b0cd1012de2b.gif)

## Unity Project 요약

- PDS 알고리즘으로 생성한 3D Position에 파란 공 오브젝트를 생성한다.
- CustomEditor를 통해 인게임에서 mesh의 생성 및 삭제를 할 수 있다.

## 프로젝트 발전 방향

- Perlin Noise를 PDS에 적용해 균질적인 배치에서 좀더 자연스러운 비균질적인 배치를 구현한다.

## Reference

- http://devmag.org.za/2009/05/03/poisson-disk-sampling/
- https://ko.wikipedia.org/wiki/%EA%B7%B9%EC%A2%8C%ED%91%9C%EA%B3%84
