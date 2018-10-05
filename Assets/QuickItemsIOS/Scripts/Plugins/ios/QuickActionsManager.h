//
//  QuickActionsManager.h
//  Created by Vladislav Hartanovich on 29.09.2018.
//

@interface QuickActionsManager : NSObject { }

@property (nonatomic, strong) NSString *currentItem;
@property (nonatomic, strong) NSString *emptyItem;

+ (QuickActionsManager *)instance;

- (void) onShortcutItem: (UIApplicationShortcutItem*) item;
- (int) getNumberOfShortcuts;
- (void) onDidEnterBackground;
- (UIApplicationShortcutItem*) getItemAtIndex: (int) i;
- (BOOL) removeItemFromExisting: (const char*) itemType;
- (BOOL) removeItemAtIndex: (int) i;
- (void) setItem: (const char*)itemType title:(const char*)localizedTitle subtitle:(const char*)localizedSubtitle customName:(const char*)customIconName iconName:(const char*)builtinIconName;

@end
