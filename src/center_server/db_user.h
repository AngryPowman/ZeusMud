#ifndef __DB_USER_H__
#define __DB_USER_H__

#include <common.h>

struct DBUser
{
    uint64 user_id;
    std::string email;
    std::string password_hash;
    uint8 gender;
    std::string nickname;
    std::string register_ip;
    int32 register_timestamp;
};

#endif