module Game
open GameMap
open Render


let drawMapElement x y value =
 match value with 
 |1 | 3 -> drawRect (x*50) (y*50) 50 50
 | _ -> ()


let drawMap() = Array2D.iteri drawMapElement minimap



let renderFrame()  = 
 drawMap()
 