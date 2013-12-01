#ifndef __ITEM_STORAGE_H__
#define __ITEM_STORAGE_H__

#include <common.h>
#include <singleton.h>

template <typename T>
class ItemStorage
    : public Venus::Singleton<ItemStorage>
{
public:
    bool addItem(T* item) = 0;

private:
    adap_map<uint64, T*> _items;
};

#endif