#ifndef __GAME_UTIL_H__
#define __GAME_UTIL_H__

#include <common.h>
#include <regex>

namespace GameUtil
{
    //ͨ�������ʺ�ת��ΪΨһID
    uint64 toUniqueId(const std::string& email)
    {
        size_t len = email.size();
        unsigned long h = (unsigned long)len;
        size_t step = (len >> 5) + 1;
        for (size_t i = len; i >= step; i -= step)
            h = h ^ ((h << 5) + (h >> 2) + (unsigned long)email.at(i - 1));
        return h;
    }

    //��֤�����ʺźϷ���
    bool checkEmailValid(const std::string& email)
    {
        const std::regex regex("(\\w+)(\\.|_)?(\\w*)@(\\w+)(\\.(\\w+))+");
        return std::regex_match(email, regex);
    }

    //��֤������Ϸ��ԣ��Ƿ�32λMD5��
    bool checkPasswordHashValid(const std::string& passwordHash)
    {
        std::regex regex("[a-fA-F0-9]{32,32}");
        return std::regex_match(passwordHash, regex);
    }

}

#endif