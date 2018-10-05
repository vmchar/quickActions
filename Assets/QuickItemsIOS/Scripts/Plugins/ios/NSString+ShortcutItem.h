//
//  NSString+ShortcutItem.h
//  Created by Vladislav Hartanovich on 29.09.2018.
//

#import <Foundation/Foundation.h>

@interface NSString (ShortcutItem)
    -(NSString*)nullEscaped;
    +(UIApplicationShortcutIconType) typeFromString: (NSString*) description;
@end
