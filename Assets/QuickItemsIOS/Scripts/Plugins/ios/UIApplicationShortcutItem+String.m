//
//  UIApplicationShortcutItem+String.m
//  Created by Vladislav Hartanovich on 29.09.2018.
//

#import <Foundation/Foundation.h>
#import "UIApplicationShortcutItem+String.h"
#import "NSString+ShortcutItem.h"

@implementation UIApplicationShortcutItem (ToString)

- (NSString*) ToString
{
    NSString* nativeDescription = [NSString stringWithFormat:@"%@ %@ %@", [self.type nullEscaped], [self.localizedTitle nullEscaped], [self.localizedSubtitle nullEscaped] ];
    return nativeDescription;
}

@end
