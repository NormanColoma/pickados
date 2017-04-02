//
// Enumerations.swift
// 
// Code autogenerated. Do not modify this file.
//

import Foundation


enum PickResult: Int
{
	case Won = 1
	case Lost = 2
	case Push = 3
	case Unstarted = 4
	case Unfinished = 5
}

enum Result: Int
{
	case Home = 1
	case Away = 2
	case Draw = 3
}

enum Line: Int
{
	case Over = 1
	case Under = 2
}

enum Time: Int
{
	case Fulltime = 1
	case Halftime = 2
}

enum Months: Int
{
	case January = 1
	case February = 2
	case March = 3
	case April = 4
	case May = 5
	case June = 6
	case July = 7
	case August = 8
	case September = 9
	case October = 10
	case November = 11
	case December = 12
enum RequestType: Int
{
	case Modify = 1
	case Delete = 2
}

enum RequestState: Int
{
	case Open = 1
	case Accepted = 2
	case Denied = 3
	case InReview = 4
}

	