package com.lg;
import javax.persistence.*;
import java.util.ArrayList;
import java.util.List;
@Entity
@Table(name = "users")

public class User {
    @Id
    @GeneratedValue(strategy = GenerationType.IDENTITY)
    private Long id;
    @Column(nullable = false, unique = true)
    private String login;
    @Column(nullable = false)
    private String password;
    private String firstName;
    private String lastName;

    @Enumerated(EnumType.STRING)
    private Sex.sex gender;

    @OneToMany(fetch = FetchType.EAGER, cascade = CascadeType.ALL)
    private List<Role> roles = new ArrayList<>();

    @ManyToMany
    private List<UsersGroup> usersGroups = new ArrayList<>();

    @Lob
    private byte[] image;

    public User() {
    }
    public User(Long id, String login, String password, String firstName, String lastName, Sex.sex gender) {
        this.id = id;
        this.login = login;
        this.password = password;
        this.firstName = firstName;
        this.lastName = lastName;
        this.gender = gender;
    }

    public Long getId() {
        return id;
    }
    public void setId(Long id) {
        this.id = id;
    }
    public String getLogin() {
        return login;
    }
    public void setLogin(String login) {
        this.login = login;
    }
    public String getPassword() {
        return password;
    }
    public void setPassword(String password) {
        this.password = password;
    }
    public String getFirstName() {
        return firstName;
    }
    public void setFirstName(String firstName) {
        this.firstName = firstName;
    }
    public String getLastName() {
        return lastName;
    }
    public void setLastName(String lastName) {
        this.lastName = lastName;
    }

    public void setGender(Sex.sex gender) {this.gender = gender;}

    public Sex.sex getGender() {return gender;}

    public void setRoles(ArrayList<Role> roles) {this.roles = roles;}

    public List<Role> getRoles() {
        return roles;
    }

    public void setUsersGroups(ArrayList<UsersGroup> usersGroups) {this.usersGroups = usersGroups;}

    public List<UsersGroup> getUsersGroups() {
        return usersGroups;
    }

    public byte[] getImage() {
        return image;
    }

    public void setImage(byte[] image) {
        this.image = image;
    }

    //add group
    public void addGroup(UsersGroup usersGroup){
        usersGroups.add(usersGroup);
    }

    //add role
    public void addRole(Role role){
        roles.add(role);
    }
}
