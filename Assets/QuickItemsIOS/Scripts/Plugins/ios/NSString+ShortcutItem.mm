//  NSString+ShortcutItem.m
//  Created by Vladislav Hartanovich on 29.09.2018.
//

#import <Foundation/Foundation.h>
#import "NSString+ShortcutItem.h"

@implementation NSString (ShortcutItem)
    -(NSString*) nullEscaped
    {
        return self.length == 0 ? @"_" : self;
    }

    +(UIApplicationShortcutIconType) typeFromString: (NSString*) description
    {
        if([description isEqualToString:@"compose"]) return UIApplicationShortcutIconTypeCompose;
        if([description isEqualToString:@"play"]) return UIApplicationShortcutIconTypePlay;
        if([description isEqualToString:@"pause"]) return UIApplicationShortcutIconTypePause;
        if([description isEqualToString:@"add"]) return UIApplicationShortcutIconTypeAdd;
        if([description isEqualToString:@"location"]) return UIApplicationShortcutIconTypeLocation;
        if([description isEqualToString:@"search"]) return UIApplicationShortcutIconTypeSearch;
        if([description isEqualToString:@"share"]) return UIApplicationShortcutIconTypeShare;
        if([description isEqualToString:@"prohibit"]) return UIApplicationShortcutIconTypeProhibit;
        if([description isEqualToString:@"contact"]) return UIApplicationShortcutIconTypeContact;
        if([description isEqualToString:@"home"]) return UIApplicationShortcutIconTypeHome;
        if([description isEqualToString:@"marklocation"]) return UIApplicationShortcutIconTypeMarkLocation;
        if([description isEqualToString:@"favorite"]) return UIApplicationShortcutIconTypeFavorite;
        if([description isEqualToString:@"love"]) return UIApplicationShortcutIconTypeLove;
        if([description isEqualToString:@"cloud"]) return UIApplicationShortcutIconTypeCloud;
        if([description isEqualToString:@"invitation"]) return UIApplicationShortcutIconTypeInvitation;
        if([description isEqualToString:@"confirmation"]) return UIApplicationShortcutIconTypeConfirmation;
        if([description isEqualToString:@"mail"]) return UIApplicationShortcutIconTypeMail;
        if([description isEqualToString:@"message"]) return UIApplicationShortcutIconTypeMessage;
        if([description isEqualToString:@"date"]) return UIApplicationShortcutIconTypeDate;
        if([description isEqualToString:@"time"]) return UIApplicationShortcutIconTypeTime;
        if([description isEqualToString:@"photo"]) return UIApplicationShortcutIconTypeCapturePhoto;
        if([description isEqualToString:@"video"]) return UIApplicationShortcutIconTypeCaptureVideo;
        if([description isEqualToString:@"task"]) return UIApplicationShortcutIconTypeTask;
        if([description isEqualToString:@"taskcompleted"]) return UIApplicationShortcutIconTypeTaskCompleted;
        if([description isEqualToString:@"alarm"]) return UIApplicationShortcutIconTypeAlarm;
        if([description isEqualToString:@"bookmark"]) return UIApplicationShortcutIconTypeBookmark;
        if([description isEqualToString:@"shuffle"]) return UIApplicationShortcutIconTypeShuffle;
        if([description isEqualToString:@"audio"]) return UIApplicationShortcutIconTypeAudio;
        if([description isEqualToString:@"update"]) return UIApplicationShortcutIconTypeUpdate;
        if([description isEqualToString:@""]) return UIApplicationShortcutIconTypeMessage;
    }

@end

