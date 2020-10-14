# 3D World에서 2D 좌표를 통해 Simple Poisson Disk Sampling 구현

## 개요

- Poisson Disk Sampling의 결과를 토대로 Unity에서 나무 오브젝트를 생성한다.
- 이 때, y 위치는 0으로 고정한다.
> ![2nd_image](https://user-images.githubusercontent.com/58730856/96007241-410af180-0e79-11eb-81a3-1076ec5ef4e3.gif)

## Unity Project 요약

- PDS 알고리즘으로 생성한 2D Position에 나무 오브젝트를 생성한다.
- CustomEditor를 통해 인게임에서 mesh의 생성 및 삭제를 할 수 있다.

## 프로젝트 발전 방향

- 이전에 구현한 Procedural Geometry Generator를 통해 나무 오브젝트의 y위치를 조정한다.

## Reference

- http://devmag.org.za/2009/05/03/poisson-disk-sampling/
