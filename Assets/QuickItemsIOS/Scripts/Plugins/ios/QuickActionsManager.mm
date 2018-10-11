//
//  QuickActionsManager.m
//  Created by Vladislav Hartanovich on 29.09.2018.
//

#import <Foundation/Foundation.h>
#import "QuickActionsManager.h"
#import <UIKit/UIKit.h>
#import "NSString+ShortcutItem.h"
#import "UIApplicationShortcutItem+String.h"

@implementation QuickActionsManager

/* singleton implementation */
+ (instancetype)instance
{
    static QuickActionsManager *quickActionsManager = nil;
    static dispatch_once_t onceToken;
    dispatch_once(&onceToken, ^{
        quickActionsManager = [[self alloc] init];
        quickActionsManager.emptyItem = @"_ _";
        quickActionsManager.currentItem = nil;
    });
    return quickActionsManager;
}

#pragma mark - AppDelegate Callbacks

/* Caching shortcut item passed from appDelegate */
- (void) onShortcutItem: (UIApplicationShortcutItem*) item
{
    NSString* nativeDescription = [item ToString];
    self.currentItem = nativeDescription;
}

/* Resetting current cached shortcur item when application is moved to background */
- (void) onDidEnterBackground
{
    self.currentItem = nil;
}

/* Get number of current available Quick Actions */
- (int) getNumberOfShortcuts
{
    NSArray <UIApplicationShortcutItem *> *existingShortcutItems = [[UIApplication sharedApplication] shortcutItems];
    return (int)existingShortcutItems.count;
}

/* Get shortcut item at given index from set shortcut items list*/
- (UIApplicationShortcutItem*) getItemAtIndex: (int) i
{
    NSArray <UIApplicationShortcutItem *> *existingShortcutItems = [[UIApplication sharedApplication] shortcutItems];
    if(existingShortcutItems.count <= i) return nil;
    return existingShortcutItems[i];
}

/* Find shortcut item with given type and remove it from active list */
- (BOOL) removeItemFromExisting: (const char*) itemType
{
    UIApplicationShortcutItem* selectedItem;
    NSString* itemString = CreateNSString(itemType);
    NSArray <UIApplicationShortcutItem *> *existingShortcutItems = [[UIApplication sharedApplication] shortcutItems];
    for (UIApplicationShortcutItem* item in existingShortcutItems)
    {
        if([item.type isEqualToString: itemString])
        {
            selectedItem = item;
            break;
        }
    }
    if(selectedItem == nil) return NO;
    
    NSMutableArray* mutableItems = [NSMutableArray arrayWithArray:existingShortcutItems];
    [mutableItems removeObject:selectedItem];
    [UIApplication sharedApplication].shortcutItems = [NSArray arrayWithArray:mutableItems];
    return YES;
}

/* Get list of set shortcuе items and remove one at specified index */
- (BOOL) removeItemAtIndex: (int) i
{
    NSArray <UIApplicationShortcutItem *> *existingShortcutItems = [[UIApplication sharedApplication] shortcutItems];
    if(existingShortcutItems.count == 0) return NO;
    if(existingShortcutItems.count <= i) return NO;
    NSMutableArray *mutableItems = [NSMutableArray arrayWithArray:existingShortcutItems];
    [mutableItems removeObjectAtIndex:i];
    [UIApplication sharedApplication].shortcutItems = mutableItems;
    return YES;
}

/* Add new shortcut item to the application. All fields are validated.
 If no name for custom icon passed - built in icon will be used.
 If no built in icon is found - no icon will be set.
*/
- (void) setItem: (const char*)itemType title:(const char*)localizedTitle subtitle:(const char*)localizedSubtitle customName:(const char*)customIconName iconName:(const char*)builtinIconName
{
    
    NSString* type = CreateNSString(itemType);
    if(type == nil || type.length == 0 || [type isEqualToString:@"_"])
    {
        NSLog(@"Error while setting new Shortcut item. Reason : empty type");
        return;
    }
    NSString* title = CreateNSString(localizedTitle);
    if(title == nil || title.length == 0 || [type isEqualToString:@"_"])
    {
        NSLog(@"Error while setting new Shortcut item. Reason : empty title");
        return;
    }
    NSString* subtitle = CreateNSString(localizedSubtitle);
    NSString* customIcon = CreateNSString(customIconName);
    NSString* builtinIcon = CreateNSString(builtinIconName);
    
    NSLog(@"type - %@ title -%@  subtitle -%@ custom -  %@, default - %@", type, title, subtitle, customIcon, builtinIcon);
    
    UIApplicationShortcutIcon* iconItem;
    //Check if there is custom icon name set
    if( customIcon != nil && ![customIcon isEqualToString:@"_"] && customIcon.length > 0) {
        iconItem = [UIApplicationShortcutIcon iconWithTemplateImageName:customIcon];
    }
    else
    {
        //If there is no custom icon -> trying to set one of the native icons
        if(builtinIcon != nil && ![builtinIcon isEqualToString:@"_"] && builtinIcon.length > 0){
            NSLog(@"icon name %@", builtinIcon);
            iconItem = [UIApplicationShortcutIcon iconWithType: [NSString typeFromString:builtinIcon]];
        }
    }
    //Create new item instance with all our params
    UIApplicationShortcutItem* newItem = [[UIApplicationShortcutItem alloc] initWithType:type localizedTitle:title localizedSubtitle:subtitle icon:iconItem userInfo:nil];
    NSMutableArray* existingItems = [NSMutableArray arrayWithArray:[[UIApplication sharedApplication] shortcutItems]];
    if(existingItems == nil) {
        existingItems = [NSMutableArray arrayWithArray:@[newItem]];
        
    }
    else {
        [existingItems addObject:newItem];
    }
    NSArray* newItemsArray = [NSArray arrayWithArray:existingItems];
    [UIApplication sharedApplication].shortcutItems = newItemsArray;
    
    NSLog(@"%d number of items", [self getNumberOfShortcuts]);
}

NSString* CreateNSString (const char* string)
{
    if (string)
        return [NSString stringWithUTF8String: string];
    else
        return [NSString stringWithUTF8String: ""];
}

@end

#pragma mark -  Unity3D Helpers
char* cStringAFCopy(const char* string)
{
    if (string == NULL)
        return NULL;
    
    char* res = (char*)malloc(strlen(string) + 1);
    strcpy(res, string);
    
    return res;
}

#pragma mark - Unity3D Available Methods
extern "C"
{
    int getNumberOfShortcuts() { return [[QuickActionsManager instance] getNumberOfShortcuts]; }
    
    char* getCurrentItem()
    {
        NSString* retVal = QuickActionsManager.instance.currentItem == nil ? QuickActionsManager.instance.emptyItem : QuickActionsManager.instance.currentItem;
        return cStringAFCopy([retVal UTF8String]);
    }
    
    char* getItemAtIndex(int i)
    {
        UIApplicationShortcutItem* item = [QuickActionsManager.instance getItemAtIndex:i];
        if(item == nil) return cStringAFCopy([QuickActionsManager.instance.emptyItem UTF8String]);
        return cStringAFCopy([[item ToString] UTF8String]);
    }
    
    bool removeItem(const char* itemType)
    {
        return [QuickActionsManager.instance removeItemFromExisting: itemType];
    }
    
    bool removeItemAtIndex(int i)
    {
        return [[QuickActionsManager instance] removeItemAtIndex:i];
    }
    
    void setItem( const char* itemType, const char* localizedTitle, const char* localizedSubtitle, const char* customIconName, const char* builtinIconName)
    {
        [QuickActionsManager.instance setItem:itemType title:localizedTitle subtitle:localizedSubtitle customName:customIconName iconName:builtinIconName];
    }
    
}

