/*
    Positiontracker & server for ELRO Wants To Play
    Copyright (C) 2015 Niek Arends
    Copyright (C) 2015 Olaf van der Kruk
    Copyright (C) 2015 Simon Voordouw

    This program is free software: you can redistribute it and/or modify
    it under the terms of the GNU General Public License as published by
    the Free Software Foundation, either version 3 of the License, or
    (at your option) any later version.

    This program is distributed in the hope that it will be useful,
    but WITHOUT ANY WARRANTY; without even the implied warranty of
    MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
    GNU General Public License for more details.

    You should have received a copy of the GNU General Public License
    along with this program.  If not, see <http://www.gnu.org/licenses/>.
 */

#pragma once

#include <vector>
#include <opencv2/highgui/highgui.hpp>
#include <opencv2/imgproc/imgproc.hpp>
#include <opencv2/opencv.hpp>

/**
*	Struct used for storing keypoints (coordinates) and their corresponding color
*	\param keypoint coordinates for the keyppoint
*	\param color RGB color representation of the keypoint
*
*/
struct KeyPointColor{
    cv::KeyPoint keypoint;
    cv::Vec3b color;

    KeyPointColor(cv::KeyPoint keypoint, cv::Vec3b color)
        : keypoint(keypoint)
        , color(color)
    {}
};

/**
*	Defines an upper and lower value
*	\param lower,upper low and high bound
*/
struct Bound {
    int lower;
    int upper;
};

class tracker
{
public:
	/**
	*	Constructor
	*	\param cap Input video capture
	*	\param debug Enables/disables debugging mode
	*/
    tracker(cv::VideoCapture cap, bool debug);
    ~tracker();

	/**
	*	Function to be called when objects have to be tracked
	*/
    std::vector<KeyPointColor> trackObjects();

	/**
	*	Function to be called when objects have to be tracked
	*	\param img_filename input filename
	*/
    std::vector<KeyPointColor> trackObjects(const std::string& img_filename); 

	/**
	*	Function to be called when objects have to be tracked
	*	\param img Input image
	*/
	std::vector<KeyPointColor> trackObjects(const cv::Mat& img);

	/**
	*	Shows debug windows when enabled
	*	\param b Enables or disables debug
	*/
    void show_debug_window(bool b) { debug = b; }
private:
	
    cv::VideoCapture cap;						//The capture device used for trackign objects
    bool debug;									//Boolean to enable debug mode
    Bound hue, saturation, value;				//HSV: Bounds in between the HSV filter will operate
    Bound area, threshold;
    int minCircularity, minConvexity,			//Blobtracking: Minimum Circularity, minimum Convexity, minimum Inertia, blobcolor
        minInertiaRatio, blobColor; 
    std::vector<KeyPointColor> trackingResult;	//The vector in which the result is stored
	cv::SimpleBlobDetector::Params params;		//Used for storing blob tracking parameters in an openCV way

	/**
	*	Will output an image based on the values set for HSV
	*	\param img Input image
	*	\return the new filtered image
	*/
    cv::Mat filterUsingHSV(const cv::Mat& img);

	/**
	*	Returns a keypoint vector based on the values set for the blobtracking
	*	\param img Input image
	*	\return Vector with blob coordinates
	*/
    std::vector<cv::KeyPoint> trackBlob(const cv::Mat& img);

	/**
	*	Will return keypointcolors based on an inpput image and input keypoints
	*	\param img Input img
	*	\param keypoints Input keypoints
	*	\return vector with keypointcolors
	*/
    std::vector<KeyPointColor> getKeypointColors(const cv::Mat& img, 
                                                     const std::vector<cv::KeyPoint>& keypoints);

	/**
	*	Used for drawing blobs and keypoints on an image
	*	\param Input image (on which the keypoints have to be drawn)
	*	\param keypointcolors vector with keypointcolors
	*/
    void drawPoints(cv::Mat& img, std::vector<KeyPointColor> keypointcolors);
     
};
