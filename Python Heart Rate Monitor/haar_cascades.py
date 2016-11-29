# -*- coding: utf-8 -*-
import cv2
import numpy as np

# import Haar Cascades
# need to change the path to where they are stored on your computer
face_cascade = cv2.CascadeClassifier('C:\Users\eoinr_000\Documents\Python\haarcascade_frontalface_default.xml')
eye_cascade = cv2.CascadeClassifier('C:\Users\eoinr_000\Documents\Python\haarcascade_eye.xml')



# initialize camera
cap = cv2.VideoCapture(0)


while True:

    # global variables for forhead rectange
    forehead_x = 1000000
    forehead_y = 1000000
    forehead_MaxX = 0
    forehead_MaxY = 1000000
    forehead_w = 0

    ret, img = cap.read()

    gray = cv2.cvtColor(img, cv2.COLOR_BGR2GRAY)

    faces = face_cascade.detectMultiScale(gray, 1.3, 5)

    for(x, y, w, h) in faces:
        cv2.rectangle(img, (x, y), (x+w, y+h), (255, 0, 0), 2)
        roi_gray = gray[y:y+h, x:x+w]
        roi_color = img[y:y+h, x:x+w]
        eyes = eye_cascade.detectMultiScale(roi_gray)

        # only look for eyes in an area already identified face

        for(ex, ey, ew, eh) in eyes:
            cv2.rectangle(roi_color, (ex, ey), (ex+ew, ey+eh), (0,255,0), 2)
            
            # the height of the box needs to be here since it is dependant on the eyes           
            if ey < forehead_MaxY:
                forehead_MaxY = ey + y

        # assign the rest of the coordinates for the ROI and draw a box;
        if x < forehead_x:
             forehead_x = x + 50
        if x+w > forehead_MaxX:
            forehead_MaxX = x+w - 50
        if y < forehead_y:
            forehead_y = y
            
        cv2.rectangle(img, (forehead_x, forehead_y), (forehead_MaxX, forehead_MaxY), (0,0,255),2)

        # create ROI from these coordinates
        roi_forehead = img[forehead_y:forehead_MaxY, forehead_x:forehead_MaxX]
        
        # calculate the average colour
        
        ###this just calculates average position within the ROI
        #avgColor = np.average(roi_forehead)        
        #print avgColor


    # display the video feed
    cv2.imshow('img', img)

    # exit the program
    k = cv2.waitKey(30) & 0xff
    if k == 27:
        break 
        
cap.release()
cv2.destroyAllWindows()
    