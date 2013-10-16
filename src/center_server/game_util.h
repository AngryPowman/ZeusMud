#ifndef __GAME_UTIL_H__
#define __GAME_UTIL_H__

#include <singleton.h>

class GameUtil
    : public Venus::Singleton<GameUtil>
{
public:
    uint64 toUniqueId(const std::string& email)
    {
        size_t len = email.size();
        unsigned long h = (unsigned long)len;
        size_t step = (len >> 5) + 1;
        for (size_t i = len; i >= step; i -= step)
            h = h ^ ((h << 5) + (h >> 2) + (unsigned long)email.at(i - 1));
        return h;
    }
};

#endif